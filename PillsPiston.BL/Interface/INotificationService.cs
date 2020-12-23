using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PillsPiston.BL.Interface
{
    public interface INotificationService
    {
        public Task AcceptNotification(int id, string userId);

    }
}
