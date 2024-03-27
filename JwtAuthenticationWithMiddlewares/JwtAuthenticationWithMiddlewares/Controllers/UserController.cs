using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JwtAuthenticationWithMiddlewares.Services.UserService;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("CreateUser")]

        public BaseResponse CreateUser(CreateUserRequest request)
        {
            return userService.CreateUser(request);
        }
    }
}
