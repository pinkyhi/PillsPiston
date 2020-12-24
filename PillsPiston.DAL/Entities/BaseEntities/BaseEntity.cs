using System.ComponentModel.DataAnnotations;

namespace PillsPiston.DAL.Entities.BaseEntities
{
    public abstract class BaseEntity : BaseDto
    {
        [Key]
        public int Id { get; set; }
    }
}
