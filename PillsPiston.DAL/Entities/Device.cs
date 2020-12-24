using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PillsPiston.DAL.Entities
{
    public class Device : BaseDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public DeviceModelsEnum Model { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<Cell> Cells { get; set; }
    }
}
