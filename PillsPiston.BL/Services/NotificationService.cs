using Microsoft.EntityFrameworkCore;
using PillsPiston.BL.Interface;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;
using PillsPiston.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.BL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository repository;

        public NotificationService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AcceptNotification(int id, string userId)
        {
            Notification notification = await this.repository.GetAsync<Notification>(true, n => n.Id == id, e => e.Include(n => n.Cell).ThenInclude(c => c.Device).ThenInclude(d => d.User).ThenInclude(u => u.Watchers));
            if (notification.Cell.Device.User.Id.Equals(userId) || notification.Cell.Device.User.Watchers.Any(w => w.WatcherId.Equals(userId)))
            {
                notification.NotificationStatus = NotificationStatusesEnum.Accepted;
                await this.repository.UpdateAsync(notification);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
