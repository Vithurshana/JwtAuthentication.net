using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.StoryService
{
    public interface IStoryService
    {
        BaseResponse CreateStory(CreateStoryRequest request);

        BaseResponse StoryList();

        BaseResponse GetStoryByUserId(long userId);
    }
}
