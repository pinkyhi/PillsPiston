using PillsPiston.DAL.Entities.BaseEntities;
using System;

namespace PillsPiston.DAL.Entities
{
    public class Adoption : BaseEntity
    {
        public string CellId { get; set; }

        public Cell Cell { get; set; }

        public string Name { get; set; }

        public TimeSpan Time { get; set; }
    }
}
