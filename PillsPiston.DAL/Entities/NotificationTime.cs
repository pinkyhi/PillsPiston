using PillsPiston.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.DAL.Entities
{
    public class NotificationTime : BaseEntity
    {
        public DateTime DateTime { get; set; }

        public int NotificationId { get; set; }

        public Notification Notification { get; set; }
    }
}
