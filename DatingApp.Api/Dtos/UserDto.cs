using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.Dtos
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }  

        [Required] 
        [StringLength(15)]
        public string Password { get; set; }  
    }
}