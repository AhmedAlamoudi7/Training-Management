using Microsoft.AspNetCore.Http;
  using System.ComponentModel.DataAnnotations;
using TrainingManagement.Constants;
using TrainingManagement.ViewModels;

namespace TrainingManagement.Core.Dtos
{
    public class UpdateApplicationUserDto
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = Message.DescriptionEmail)]
        //[RegularExpression(Message.RegularExpEmail)]
        public string Email { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
