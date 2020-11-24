using PillsPiston.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.DAL.Entities
{
    public class Notification : BaseEntity
    {
        public string CellId { get; set; }

        public Cell Cell { get; set; }

        public int NotificationStatus { get; set; }
    }
}
