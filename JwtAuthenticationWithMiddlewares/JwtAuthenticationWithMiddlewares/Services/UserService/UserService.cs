using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;
using JwtAuthenticationWithMiddlewares.Models;

namespace JwtAuthenticationWithMiddlewares.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse CreateUser(CreateUserRequest request)
        {
            BaseResponse response;

            try
            {
                UserModel newUser = new UserModel();

                newUser.user_name = request.user_name;
                newUser.email = request.email;
                newUser.password = Supports.GenerateMD5(request.password);
                newUser.last_name = request.last_name;
                newUser.first_name = request.first_name;

                using (context)
                {
                    context.Add(newUser);
                    context.SaveChanges();


                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { message = "Successfully created the new user" }
                    };
                }

                return response;

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
