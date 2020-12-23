using AutoMapper;
using PillsPiston.BL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.API.Requests.Profile
{
    [AutoMap(typeof(AdoptionContract), ReverseMap = true)]
    public class NewAdoptionRequest
    {
        public string CellId { get; set; }

        public string Name { get; set; }

        public TimeSpan Time { get; set; }
    }
}
