using AutoMapper;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillsPiston.BL.Contracts
{
    [AutoMap(typeof(Device))]
    public class DeviceContract
    {
        public DeviceModelsEnum Model { get; set; }
    }
}
