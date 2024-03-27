using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.AuthenticateService
{
    public interface IAutheticateService
    {
        BaseResponse Authenticate(AuthenticateRequest request);
    }
}
