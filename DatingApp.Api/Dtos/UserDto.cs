using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.Dtos
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }  

        [Required] 
        [MinLength(4), MaxLength(15)]
        public string Password { get; set; }  
    }
}