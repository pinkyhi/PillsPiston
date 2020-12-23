using Microsoft.EntityFrameworkCore;
using PillsPiston.BL.Interface;
using PillsPiston.Core.Exceptions.Device;
using PillsPiston.DAL.Entities;
using PillsPiston.DAL.Interfaces;
using PillsPiston.DAL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillsPiston.BL.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepository repository;
        private readonly UserManager userManager;

        public DeviceService(IRepository repository, UserManager userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        public async Task ConnectCellToDevice(string cellId, string deviceId)
        {
            Cell cell = await repository.GetAsync<Cell>(true, u => u.Id.Equals(cellId));
            if (!string.IsNullOrEmpty(cell.DeviceId))
            {
                throw new ElementAlreadyConnectedException();
            }
            else
            {
                Device device = await repository.GetAsync<Device>(true, u => u.Id.Equals(deviceId), u => u.Include(e => e.Cells));
                var cells = device.Cells.ToList();
                cells.Add(cell);
                device.Cells = cells;
                await this.repository.UpdateAsync(device);
            }
        }

        public async Task ConnectDeviceToUser(string deviceId, string userId)
        {
            Device device = await repository.GetAsync<Device>(true, u => u.Id.Equals(deviceId));
            if(!string.IsNullOrEmpty(device.UserId))
            {
                throw new ElementAlreadyConnectedException();
            }
            else
            {
                User user = await this.userManager.FindAsync(u => u.Id.Equals(userId), u => u.Include(e => e.Devices));
                var devices = user.Devices.ToList();
                devices.Add(device);
                user.Devices = devices;
                await this.userManager.UpdateAsync(user);
            }
        }

        public async Task DisconnectCellFromDevice(string cellId, string deviceId)
        {
            Device device = await repository.GetAsync<Device>(true, u => u.Id.Equals(deviceId), u => u.Include(e => e.Cells));
            Cell cell = device.Cells.FirstOrDefault(e => e.Id.Equals(cellId));
            if (cell == null)
            {
                throw new ElementNotConnectedException();
            }
            else
            {
                var cells = device.Cells.ToList();
                cells.Remove(cell);
                device.Cells = cells;
                await repository.UpdateAsync(device);
            }

        }

        public async Task DisconnectDeviceFromUser(string deviceId, string userId)
        {
            User user = await userManager.FindAsync(u => u.Id.Equals(userId), u => u.Include(e => e.Devices));
            Device device = user.Devices.FirstOrDefault(e => e.Id.Equals(deviceId));
            if (device == null)
            {
                throw new ElementNotConnectedException();
            }
            else
            {
                var devices = user.Devices.ToList();
                devices.Remove(device);
                user.Devices = devices;
                await this.userManager.UpdateAsync(user);
            }
        }
    }
}
