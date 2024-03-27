using System.ComponentModel.DataAnnotations;

namespace JwtAuthenticationWithMiddlewares.DTOs.Requests
{
    public class AuthenticateRequest
    {
        /*[Required]
        public string user_id { get; set; }

        [Required]
        public string token { get; set; }*/

        [Required]
        public string user_name { get; set; }

        [Required]
        public string password { get; set; }
    }
}
