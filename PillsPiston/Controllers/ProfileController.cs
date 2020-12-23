using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillsPiston.API.Requests.Profile;
using PillsPiston.API.Routes;
using PillsPiston.BL.Interface;
using PillsPiston.Core.Resources;
using PillsPiston.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PillsPiston.Controllers
{
    [ApiController]
    [ModelValidation]
    [ServiceFilter(typeof(ExceptionFilterAttribute))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpPost(DefaultRoutes.Profile.Cells)]
        public async Task<IActionResult> RenameCell([FromBody] RenameCellRequest request)
        {
            var cell = await profileService.RenameCell(request.CellId, request.Name);
            return Ok(cell);
        }

        [HttpPost(DefaultRoutes.Profile.Relationships)]
        public async Task<IActionResult> AcceptWatchRequest([FromBody] RelationshipAcceptRequest request)
        {
            var subjectId = this.User.Claims.First(c => c.Type == StringConstants.JwtClaimId).Value;
            await profileService.AcceptWatchRequest(request.WatcherId, subjectId);
            return Ok();
        }

        [HttpDelete(DefaultRoutes.Profile.Relationships)]
        public async Task<IActionResult> RejectWatchRequest([FromBody] RelationshipAcceptRequest request)
        {
            var subjectId = this.User.Claims.First(c => c.Type == StringConstants.JwtClaimId).Value;
            await profileService.RejectWatchRequest(request.WatcherId, subjectId);
            return Ok();
        }

        [HttpPatch(DefaultRoutes.Profile.Relationships)]
        public async Task StopWatchRequest([FromBody] RelationshipStopRequest request)
        {
            var userId = this.User.Claims.First(c => c.Type == StringConstants.JwtClaimId).Value;
            if (request.IsFromSubject)
            {
                await profileService.StopWatchRequest(request.MateId, userId);
            }
            else
            {
                await profileService.StopWatchRequest(userId, request.MateId);

            }
        }

        [HttpPut(DefaultRoutes.Profile.Relationships)]
        public async Task<IActionResult> SendWatchRequest([FromBody] RelationshipSendRequest request)
        {
            var watcherId = this.User.Claims.First(c => c.Type == StringConstants.JwtClaimId).Value;
            var relationship = await profileService.SendWatchRequest(watcherId, request.SubjectId);
            return Ok(relationship);
        }
    }
}
