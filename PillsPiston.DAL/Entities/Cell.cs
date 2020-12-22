using PillsPiston.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PillsPiston.DAL.Entities
{
    public class Cell : BaseDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public string DeviceId { get; set; }

        public Device Device { get; set; }

        public string Name { get; set; }

        public IEnumerable<Adoption> Adoptions { get; set; }

        public IEnumerable<Notification> Notifications { get; set; }
    }
}
