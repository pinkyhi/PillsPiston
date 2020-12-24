using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PillsPiston.API.Requests.Identity;
using PillsPiston.API.Responses.Identity;
using PillsPiston.DAL.Entities;
using PillsPiston.Filters;
using PillsPiston.WebServices.Interfaces;
using System.Threading.Tasks;

namespace PillsPiston.Controllers
{
    [ApiController]
    [ModelValidation]
    [ServiceFilter(typeof(ExceptionFilterAttribute))]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> userManager;
        public IdentityController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IIdentityService identityService, IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
            _roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpPost(API.Routes.DefaultRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResult = await this.identityService.RegisterAsync(request.Email, request.UserName, request.Password);

            return this.Ok(this.mapper.Map<AuthSuccessResponse>(authResult));
        }

        [HttpPost(API.Routes.DefaultRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResult = await this.identityService.LoginAsync(request.Email, request.Password);
            return this.Ok(this.mapper.Map<AuthSuccessResponse>(authResult));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(API.Routes.DefaultRoutes.Identity.Logout)]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete("JwtToken");
            return this.Ok();
        }

        [HttpPost(API.Routes.DefaultRoutes.Identity.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var authResult = await this.identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

            return this.Ok(this.mapper.Map<AuthSuccessResponse>(authResult));
        }
    }
}
