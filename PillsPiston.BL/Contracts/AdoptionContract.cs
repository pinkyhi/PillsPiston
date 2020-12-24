using AutoMapper;
using PillsPiston.DAL.Entities;
using System;

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
