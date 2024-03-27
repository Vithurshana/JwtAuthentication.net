using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Services.AuthenticateService;
using JwtAuthenticationWithMiddlewares.Services.StoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAutheticateService authenticateService;

        public AuthenticateController(IAutheticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [HttpPost("Authenticate")]
        public BaseResponse Authenticate(AuthenticateRequest request)
        {
            return authenticateService.Authenticate(request);
        }
    }
}
