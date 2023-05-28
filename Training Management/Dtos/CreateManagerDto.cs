 using System.ComponentModel.DataAnnotations;
using Training_Management.Enums;
using Training_Management.Models;
using static TrainingManagement.Constants.Message;
using TrainingManagement.ViewModels;
using TrainingManagement.Constants;

namespace Training_Management.Dtos
{
    public class CreateManagerDto
    {
        [Required]
        //[RegularExpression(Message.RegularExpEmail)]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        [Display(Name = Message.DescriptionEmail)]
        //[RegularExpression(Message.RegularExpEmail)]
        public string Email { get; set; }

        [Required]
        [StringLength(Message.MaxLength100, ErrorMessage = Message.ErrorMessage.Max100_Min6Length, MinimumLength = Message.MinLength6)]
        [DataType(DataType.Password)]
        [Display(Name = Message.DescriptionPassword)]
        public string Password { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
