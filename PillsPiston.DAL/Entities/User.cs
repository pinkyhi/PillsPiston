using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PillsPiston.DAL.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public DateTime RegistrationDate { get; set; }

        public IEnumerable<Relationship> Watchers { get; set; }

        public IEnumerable<Relationship> Subjects { get; set; }

        public IEnumerable<Device> Devices { get; set; } 
    }
}
