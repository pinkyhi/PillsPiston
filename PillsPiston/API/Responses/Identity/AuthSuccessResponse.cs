using AutoMapper;
using PillsPiston.WebServices.Results;

namespace PillsPiston.API.Responses.Identity
{
    [AutoMap(typeof(AuthentificationResult))]
    public class AuthSuccessResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
