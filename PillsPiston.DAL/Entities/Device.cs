using PillsPiston.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.DAL.Entities
{
    public class Device : BaseDto
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
