using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PillsPiston.DAL.Entities.BaseEntities
{
    public abstract class BaseEntity : BaseDto
    {
        [Key]
        public int Id { get; set; }
    }
}
