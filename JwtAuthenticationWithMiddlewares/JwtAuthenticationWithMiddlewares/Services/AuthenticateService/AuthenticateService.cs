using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Models;
using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.EntityFrameworkCore;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;
using Newtonsoft.Json.Linq;

namespace JwtAuthenticationWithMiddlewares.Services.AuthenticateService
{
    public class AuthenticateService : IAutheticateService
    {
        private readonly ApplicationDbContext context;
        public AuthenticateService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public BaseResponse Authenticate(AuthenticateRequest request)
        {
            BaseResponse response;
            try
            {
                UserModel? user = context.User.Where(u => u.user_name == request.user_name).FirstOrDefault();
                if (user == null)
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status401Unauthorized,
                        data = new { message = "Invalid username or password" },
                    };
                    return response;
                }

                string md5Password = Supports.GenerateMD5(request.password);
                /*string md5Password1 = Supports.GenerateMD5(user.password);*/

                if (user.password == md5Password)
                {
                    string jwt = JwtUtils.GenerateJwtToken(user);

                    LoginDetailModel? loginDetail = context.LoginDetails.Where(Id => Id.user_id == user.id).FirstOrDefault();

                    if (loginDetail == null)
                    {
                        loginDetail = new LoginDetailModel();
                        loginDetail.user_id= user.id;
                        loginDetail.token = jwt;

                        context.LoginDetails.Add(loginDetail);
                    }

                    else
                    {
                        loginDetail.token= jwt;
                    }

                    context.SaveChanges();

                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { token = jwt },
                    };
                    return response;
                }

                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status401Unauthorized,
                        data = new { message = "Invalid username or password" },
                    };
                    return response;

                }

            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };

                return response;

            }
        }
    }
}
