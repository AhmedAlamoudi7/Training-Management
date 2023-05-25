using Microsoft.AspNetCore.Http;
  using System.ComponentModel.DataAnnotations;
using TrainingManagement.Constants;

namespace Shawrney.Core.Dtos
{
    public class UpdateApplicationUserDto
    {
        public string Id { get; set; }
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
 		//public UserRolesViewModel Roles { get; set; }
    }
}
