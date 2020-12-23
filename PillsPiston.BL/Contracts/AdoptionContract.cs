using AutoMapper;
using PillsPiston.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.BL.Contracts
{
    [AutoMap(typeof(Adoption), ReverseMap = true)]
    public class AdoptionContract
    {
        public string CellId { get; set; }

        public string Name { get; set; }

        public TimeSpan Time { get; set; }
    }
}
