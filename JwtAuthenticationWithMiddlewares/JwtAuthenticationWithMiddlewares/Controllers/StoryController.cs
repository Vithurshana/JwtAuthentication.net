using JwtAuthenticationWithMiddlewares.DTOs.Requests;
using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Services.StoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService storyService;

        public StoryController(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        [HttpPost("CreateStory")]

        public BaseResponse CreateStory(CreateStoryRequest request)
        {
            return storyService.CreateStory(request);
        }

        [HttpPost("GetAllStory")]

        public BaseResponse StoryList()
        {
            return storyService.StoryList();
        }

        [HttpPost("GetStoryByUserId")]

        public BaseResponse GetStoryByUserId(long userId)
        {
            return storyService.GetStoryByUserId(userId);
        }
    }
}
