using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;
using Training_Management.Enums;
using TrainingManagement.Constants;
using TrainingManagement.ViewModels;

namespace TrainingManagement.Dtos
{
	public class CreateAdviserDto
	{
		[Required]
		//[RegularExpression(Message.RegularExpEmail)]
		public string Name { get; set; }
		[Required]
		[EmailAddress]
		[Display(Name = Message.DescriptionEmail)]
		//[RegularExpression(Message.RegularExpEmail)]
		public string Email { get; set; }
        [Required]
        public DesciplineType DesciplineType { get; set; }
        [Required]
		[StringLength(Message.MaxLength100, ErrorMessage = Message.ErrorMessage.Max100_Min6Length, MinimumLength = Message.MinLength6)]
		[DataType(DataType.Password)]
		[Display(Name = Message.DescriptionPassword)]
		public string Password { get; set; }
        public List<RoleViewModel> Roles { get; set; }

    }
}
