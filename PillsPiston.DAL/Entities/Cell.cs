using PillsPiston.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.DAL.Entities
{
    public class Cell : BaseDto
    {
        public string Id { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }

        public string Name { get; set; }
    }
}
