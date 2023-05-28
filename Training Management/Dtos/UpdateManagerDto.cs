using System.ComponentModel.DataAnnotations;

namespace Training_Management.Dtos
{
    public class UpdateManagerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        // Add other necessary properties for manager information
        public string ApplicationUserId { get; set; }
         
    }
}
