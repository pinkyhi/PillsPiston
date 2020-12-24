using AutoMapper;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;

namespace PillsPiston.BL.Contracts
{
    [AutoMap(typeof(Cell), ReverseMap = true)]
    public class CellContract
    {
        public CellModelsEnum Model;
    }
}
