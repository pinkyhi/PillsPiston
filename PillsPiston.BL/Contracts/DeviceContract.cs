using AutoMapper;
using PillsPiston.Core.Enums;
using PillsPiston.DAL.Entities;

namespace PillsPiston.BL.Contracts
{
    [AutoMap(typeof(Device))]
    public class DeviceContract
    {
        public DeviceModelsEnum Model { get; set; }
    }
}
