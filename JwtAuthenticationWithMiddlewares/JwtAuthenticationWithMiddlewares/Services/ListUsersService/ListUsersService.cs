using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.Models;
using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.EntityFrameworkCore;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;
using Newtonsoft.Json.Linq;

namespace JwtAuthenticationWithMiddlewares.Services.ListUsersService
{
    public class ListUsersService : IListUsersService
    {
        private readonly HttpClient _httpClient;

        public ListUsersService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /*public BaseResponse ListUsers()
        {
            *//*throw new NotImplementedException();
        }*//*
            BaseResponse response1;

            try
            {
                async Task<BaseResponse> GetUsersAsync()
                {
                    BaseResponse response1;
                    try
                    {
                        string apiUrl = "https://reqres.in/api/users?page=2";

                        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonString = await response.Content.ReadAsStringAsync();
                            var responseData = JsonSerializer.Deserialize<ApiResponse>(jsonString);

                            List<ListUsersDTO> userList = new List<ListUsersDTO>();
                            foreach (var item in responseData.data)
                            {
                                userList.Add(new ListUsersDTO
                                {
                                    id = item.id,
                                    email = item.email,
                                    first_name = item.first_name,
                                    last_name = item.last_name,
                                    avatar = item.avatar
                                });
                            }

                            response1 = new BaseResponse
                            {
                                status_code = StatusCodes.Status200OK,
                                data = userList
                            };

                            return response1;
                        }
                        else
                        {
                            response1 = new BaseResponse
                            {
                                status_code = StatusCodes.Status500InternalServerError,
                                data = new { message = "Internal server error" }
                            };
                            return response1;
                        }
                    }
                    catch (Exception ex)
                    {
                        response1 = new BaseResponse
                        {
                            status_code = StatusCodes.Status500InternalServerError,
                            data = new { message = "Internal server error" + ex.Message }
                        };
                        return response1;
                    }
                }
                
            }

            catch (Exception ex)
            {
                response1 = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error" + ex.Message }
                };
                return response1;

            }
            return response1;

        }*/
        public async Task<BaseResponse> ListUsers()
        {
            BaseResponse response1;

            try
            {
                string apiUrl = "https://reqres.in/api/users?page=2";

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var responseData = JsonSerializer.Deserialize<ApiResponse>(jsonString);

                    List<ListUsersDTO> userList = new List<ListUsersDTO>();
                    foreach (var item in responseData.data)
                    {
                        userList.Add(new ListUsersDTO
                        {
                            id = item.id,
                            email = item.email,
                            first_name = item.first_name,
                            last_name = item.last_name,
                            avatar = item.avatar
                        });
                    }

                    response1 = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = userList
                    };

                    return response1;
                }
                else
                {
                    response1 = new BaseResponse
                    {
                        status_code = StatusCodes.Status500InternalServerError,
                        data = new { message = "Internal server error" }
                    };
                    return response1;
                }
            }
            catch (Exception ex)
            {
                response1 = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error" + ex.Message }
                };
                return response1;
            }
        }

    }
}


/*using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.DTOs;
using Microsoft.Extensions.Http;

namespace JwtAuthenticationWithMiddlewares.Services.ListUsersService
{
    public class ListUsersService : IListUsersService
    {
        public ListUsers()
        { 
            
            private readonly HttpClient _httpClient;

            public ListUsersService(HttpClient httpClient)
            {
                _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            }

            public async Task<BaseResponse> GetUsersAsync()
            {
                BaseResponse response1;
                try
                {
                    // Replace "your-api-url" with the actual URL of the API
                    string apiUrl = "https://reqres.in/api/users?page=2";

                    HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        var responseData = JsonSerializer.Deserialize<ApiResponse>(jsonString);

                        // Extract required data
                        List<ListUsersDTO> userList = new List<ListUsersDTO>();
                        foreach (var item in responseData.data)
                        {
                            userList.Add(new ListUsersDTO
                            {
                                id = item.id,
                                email = item.email,
                                first_name = item.first_name,
                                last_name = item.last_name,
                                avatar = item.avatar
                            });
                        }

                        response1 = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = userList
                        };

                    return response1;
                        
                    }
                    else
                    {
                        response1 = new BaseResponse
                        {
                            status_code = StatusCodes.Status500InternalServerError,
                            data = new { message = "Internal server error" }
                        };
                        return response1;
                    }
                }
                catch (Exception ex)
                {
                    response1 = new BaseResponse
                    {
                        status_code = StatusCodes.Status500InternalServerError,
                        data = new { message = "Internal server error" + ex.Message }
                    };
                    return response1;
                }
            }

        }
    }
}
*/