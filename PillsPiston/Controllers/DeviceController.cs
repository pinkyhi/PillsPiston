using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillsPiston.API.Requests.Device;
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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        [HttpPost(DefaultRoutes.Device.Cells)]
        public async Task<IActionResult> ConnectCellToDevice([FromBody] CellConnectionRequset request)
        {
            await deviceService.ConnectCellToDevice(request.CellId, request.DeviceId);
            return Ok();
        }

        [HttpDelete(DefaultRoutes.Device.Cells)]
        public async Task<IActionResult> DisconnectCellFromDevice([FromBody] CellConnectionRequset request)
        {
            await deviceService.DisconnectCellFromDevice(request.CellId, request.DeviceId);
            return Ok();
        }

        [HttpPost(DefaultRoutes.Device.Connection)]
        public async Task<IActionResult> ConnectDeviceToUser([FromBody] DeviceConnectionRequest request)
        {
            var userId = this.User.Claims.First(c => c.Type == StringConstants.JwtClaimId).Value;
            await deviceService.ConnectDeviceToUser(request.DeviceId, userId);
            return Ok();
        }

        [HttpDelete(DefaultRoutes.Device.Connection)]
        public async Task<IActionResult> DisconnectDeviceFromUser([FromBody] DeviceConnectionRequest request)
        {
            var userId = this.User.Claims.First(c => c.Type == StringConstants.JwtClaimId).Value;
            await deviceService.DisconnectDeviceFromUser(request.DeviceId, userId);
            return Ok();
        }
    }
}
