using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.UserService
{
    public interface IUserService
    {
        BaseResponse CreateUser(CreateUserRequest request);
    }
}
