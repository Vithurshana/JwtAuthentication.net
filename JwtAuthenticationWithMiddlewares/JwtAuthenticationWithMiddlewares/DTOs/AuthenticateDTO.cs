using System.ComponentModel.DataAnnotations;

namespace JwtAuthenticationWithMiddlewares.DTOs
{
    public class AuthenticateDTO
    {
        [Required]
        public long id { get; set; }

        [Required]
        public string user_id { get; set; }

        [Required]
        public string token { get; set; }

        [Required]
        public string user_name { get; set; }
    }
}
