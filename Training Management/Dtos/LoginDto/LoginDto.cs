using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Dtos.LoginDto
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
