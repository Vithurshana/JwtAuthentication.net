using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Services.ListUsersService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListUsersController : ControllerBase
    {
        private readonly IListUsersService _listUsersService;

        public ListUsersController(IListUsersService listUsersService)
        {
            _listUsersService = listUsersService;
        }

        [HttpGet("ListUsers")]
        public async Task<BaseResponse> ListUsers()
        {
            return await _listUsersService.ListUsers();
        }
    }
}


/*using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Services.ListUsersService;
using JwtAuthenticationWithMiddlewares.Services.StoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListUsersController : ControllerBase
    {

        private readonly IListUsersService listUsersService;

        public ListUsersController(IListUsersService listUsersService)
        {
            this.listUsersService = listUsersService;
        }

        [HttpPost("ListUsers")]
        public BaseResponse ListUsers()
        {
            return listUsersService.ListUsers();
        }

    }
}*/
