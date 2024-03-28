using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.ListUsersService
{
    public interface IListUsersService
    {
        /*BaseResponse ListUsers();*/
        /*Task<BaseResponse> GetUsersAsync();*/

        Task<BaseResponse> ListUsers();
    }
}
