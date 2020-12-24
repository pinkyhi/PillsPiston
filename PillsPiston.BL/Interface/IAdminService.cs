using PillsPiston.BL.Contracts;
using System.Threading.Tasks;

namespace PillsPiston.BL.Interface
{
    public interface IAdminService
    {
        Task AddNewCells(params CellContract[] cells);

        Task AddNewDevices(params DeviceContract[] devices);
    }
}
