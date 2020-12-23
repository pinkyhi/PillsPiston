using AutoMapper;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.BL.Contracts
{
    [AutoMap(typeof(Cell), ReverseMap = true)]
    public class CellContract
    {
        public CellModelsEnum Model;
    }
}
