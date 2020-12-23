using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillsPiston.API.Requests.Admin;
using PillsPiston.API.Routes;
using PillsPiston.BL.Contracts;
using PillsPiston.BL.Interface;
using PillsPiston.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillsPiston.Controllers
{
    [ApiController]
    [ModelValidation]
    [ServiceFilter(typeof(ExceptionFilterAttribute))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost(DefaultRoutes.Admin.Cells)]
        public async Task<IActionResult> AddNewCells(NewCellsRequest request)
        {
            List<CellContract> cellContracts = new List<CellContract>();
            for(int i = 0; i < request.Count; i++)
            {
                cellContracts.Append(new CellContract { Model = request.Model });
            }
            await adminService.AddNewCells(cellContracts.ToArray());
            return Ok();
        }

        [HttpPost(DefaultRoutes.Admin.Devices)]
        public async Task<IActionResult> AddNewDevices(NewDevicesRequest request)
        {
            List<DeviceContract> cellContracts = new List<DeviceContract>();
            for (int i = 0; i < request.Count; i++)
            {
                cellContracts.Append(new DeviceContract { Model = request.Model });
            }
            await adminService.AddNewDevices(cellContracts.ToArray());
            return Ok();
        }
    }
}
