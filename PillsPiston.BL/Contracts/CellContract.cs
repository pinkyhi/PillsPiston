using AutoMapper;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.BL.Contracts
{
    [AutoMap(typeof(Cell))]
    public class CellContract
    {
        public CellModelsEnum Model;
    }
}
