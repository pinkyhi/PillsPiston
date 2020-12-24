using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities.BaseEntities;
using System;

namespace PillsPiston.DAL.Entities
{
    public class Notification : BaseEntity
    {
        public string CellId { get; set; }

        public Cell Cell { get; set; }

        public NotificationStatusesEnum NotificationStatus { get; set; }

        public DateTime DateTime { get; set; }
    }
}
