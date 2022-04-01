using System.ComponentModel.DataAnnotations;

namespace KangarooTest.Models
{
    public class AuthenticateUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
