using System.Threading.Tasks;

namespace PillsPiston.BL.Interface
{
    public interface INotificationService
    {
        public Task AcceptNotification(int id, string userId);

    }
}
