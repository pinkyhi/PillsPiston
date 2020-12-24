using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillsPiston.API.Routes;
using PillsPiston.BL.Interface;
using PillsPiston.Core.Resources;
using PillsPiston.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.Controllers
{
    [ApiController]
    [ModelValidation]
    [ServiceFilter(typeof(ExceptionFilterAttribute))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpPatch(DefaultRoutes.Notification.Default)]
        public async Task<IActionResult> AcceptNotification([FromBody] int id)
        {
            var userId = this.User.Claims.First(c => c.Type == StringConstants.JwtClaimId).Value;
            await notificationService.AcceptNotification(id, userId);
            return Ok();
        }
    }
}
