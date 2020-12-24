using AutoMapper;
using PillsPiston.BL.Contracts;
using PillsPiston.BL.Interface;
using PillsPiston.DAL.Entities;
using PillsPiston.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.BL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repository;

        private readonly IMapper mapper;
        public AdminService(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task AddNewCells(params CellContract[] cells)
        {
            IEnumerable<Cell> dbCells = cells.Select(c => this.mapper.Map<Cell>(c));
            await this.repository.AddRangeAsync(dbCells);
        }

        public async Task AddNewDevices(params DeviceContract[] devices)
        {
            IEnumerable<Device> dbDevices = devices.Select(c => this.mapper.Map<Device>(c));
            await this.repository.AddRangeAsync(dbDevices);
        }
    }
}
