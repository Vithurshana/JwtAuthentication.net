using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthenticationWithMiddlewares.DTOs
{
    public class UserDTO
    {
        [Required]
        public long id { get; set; }

        [Required]
        public string user_name { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string first_name { get; set; }
    }
}
