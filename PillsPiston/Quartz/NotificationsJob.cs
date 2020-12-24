using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;
using PillsPiston.DAL.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.Quartz
{
    [DisallowConcurrentExecution]
    public class NotificationsJob : IJob
    {
        private readonly ILogger<NotificationsJob> logger;
        private readonly IRepository repository;
        public NotificationsJob(ILogger<NotificationsJob> logger, IRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            DateTime now = DateTime.Now;
            var cells = await this.repository.GetRangeAsync<Cell>(true, c => c.Adoptions.Any(a => this.CheckTime(a.Time, now)), c => c.Include(e => e.Adoptions));
            IEnumerable<Notification> notifications = cells?.Select(c => new Notification { CellId = c.Id, DateTime = now, NotificationStatus = NotificationStatusesEnum.Pending });
            if(HasSingleNotification(notifications))
            {
                await this.repository.AddRangeAsync(notifications);
            }
            logger.LogInformation($"Added {notifications?.Count()} notifications");
            //return Task.CompletedTask;
        }

        private bool CheckTime(TimeSpan time, DateTime now)
        {
            TimeSpan breakDuration = TimeSpan.FromMinutes(5);
            DateTime dateTime = new DateTime(now.Year, now.Month, now.Day, time.Hours, time.Minutes, time.Seconds);
            return (now - dateTime < breakDuration);
        }

        private bool HasSingleNotification(IEnumerable<Notification> sequence)
        {
            if (sequence is ICollection<Notification> list) return list.Count == 1; // simple case
            using (var iter = sequence.GetEnumerator())
            {
                return iter.MoveNext() && !iter.MoveNext();
            }
        }
    }
}
