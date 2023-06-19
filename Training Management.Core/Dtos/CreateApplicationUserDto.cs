using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TrainingManagement.Constants;
using TrainingManagement.ViewModels;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace TrainingManagement.Core.Dtos
{
    public class CreateApplicationUserDto
    {

        [Required(ErrorMessage = Message.ErrorMessage.RightPhoneEnter)]
        [Display(Name = Message.DescriptionPhone)]
        [RegularExpression(Message.RegularExpPhone, ErrorMessage = Message.ErrorMessage.RightPhoneEnter)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = Message.DescriptionEmail)]
        //[RegularExpression(Message.RegularExpEmail)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = Message.ErrorMessage.Max100_Min6Length, MinimumLength = Message.MinLength6)]
        [DataType(DataType.Password)]
        [Display(Name = Message.DescriptionPassword)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = Message.DescriptionConfirmPassword)]
        [Compare(Message.Password, ErrorMessage = Message.ErrorMessage.PassAndConfirmPassNotSame)]
        public string ConfirmPassword { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
