using System.ComponentModel.DataAnnotations;

namespace JwtAuthenticationWithMiddlewares.DTOs
{
    public class ListUsersDTO
    {
        [Required]
        public long id { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set;}

        [Required]
        public string avatar { get; set; }
    }

    public class ApiResponse
        {
          public List<ListUsersDTO> data { get; set; }
        }
    

}
