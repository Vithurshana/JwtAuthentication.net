using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Models;
using System.Linq.Expressions;

namespace JwtAuthenticationWithMiddlewares.Services.StoryService
{
    public class StoryService : IStoryService
    {
        private readonly ApplicationDbContext context;
        public StoryService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse CreateStory(CreateStoryRequest request)
        {
            BaseResponse response;

            try
            {
                StoryModel newStory = new StoryModel();

                newStory.user_id = request.user_id;
                newStory.title = request.title;
                newStory.description = request.description;

                using (context)
                {
                    context.Add(newStory);
                    context.SaveChanges();


                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { message = "Successfully created the new story" }
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

        public BaseResponse StoryList()
        {
            BaseResponse response;
            try
            {
                List<StoryDTO> stories = new List<StoryDTO>();

                using (context)
                {
                    context.Story.ToList().ForEach(story => stories.Add(new StoryDTO
                    {
                        id = story.id,
                        user_id = story.user_id,
                        title = story.title,    
                        description = story.description,

                    }));
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { stories }
                };

            }

            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error" + ex.Message }
                };

            }

            return response;
        }

        public BaseResponse GetStoryByUserId (long userId)
        {
            BaseResponse response;

            try
            {
                StoryDTO story = new StoryDTO();

                using (context)
                {
                    StoryModel filteredStory = context.Story.Where(story => story.user_id == userId).FirstOrDefault();

                    if (filteredStory != null)
                    {
                        story.user_id = filteredStory.user_id;
                        story.title = filteredStory.title;
                        story.description = filteredStory.description;
                    }
                    else
                    {
                        story = null;
                    }

                }
                if (story != null)
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { story }
                    };
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status400BadRequest,
                        data = new { message = "No story found" }
                    };
                }
                return response;
            }

            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error" + ex.Message }
                };

            }

            return response;
        }
    }
}
