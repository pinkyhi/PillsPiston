using System.Threading.Tasks;

namespace PillsPiston.BL.Interface
{
    public interface IDeviceService
    {
        public Task ConnectDeviceToUser(string deviceId, string userId);

        public Task DisconnectDeviceFromUser(string deviceId, string userId);

        public Task ConnectCellToDevice(string cellId, string deviceId);

        public Task DisconnectCellFromDevice(string cellId, string deviceId);
    }
}
