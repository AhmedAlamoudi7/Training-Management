using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Dtos.LoginDto
{
    public class ChangePasswordDto
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
