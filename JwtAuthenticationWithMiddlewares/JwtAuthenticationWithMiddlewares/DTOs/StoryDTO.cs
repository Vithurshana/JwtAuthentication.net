using System.ComponentModel.DataAnnotations;

namespace JwtAuthenticationWithMiddlewares.DTOs
{
    public class StoryDTO
    {
        [Required]
        public long id { get; set; }

        [Required]
        public long user_id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }
    }
}
