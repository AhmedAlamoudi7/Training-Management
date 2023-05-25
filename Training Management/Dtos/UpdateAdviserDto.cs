using Microsoft.AspNetCore.Http;
 
 using System.ComponentModel.DataAnnotations;
using TrainingManagement.Constants;

namespace Shawrney.Core.Dtos
{
    public class UpdateAdviserDto
    {
        public int Id { get; set; }
		[Required]
		//[RegularExpression(Message.RegularExpEmail)]
		public string Name { get; set; }
		[Required]
		[EmailAddress]
		[Display(Name = Message.DescriptionEmail)]
		//[RegularExpression(Message.RegularExpEmail)]
		public string Email { get; set; }
 
		[Required(ErrorMessage = Message.ErrorMessage.RightPhoneEnter)]
		[Display(Name = Message.DescriptionPhone)]
		[RegularExpression(Message.RegularExpPhone, ErrorMessage = Message.ErrorMessage.RightPhoneEnter)]
		public string Phone { get; set; }
	}
}
