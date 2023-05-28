using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;
using TrainingManagement.Constants;
using TrainingManagement.Enums;
using TrainingManagement.ViewModels;
using static TrainingManagement.Constants.Message;

namespace Training_Management.Dtos
{
	public class CreateTraineeDto
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public GenderType GenderType { get; set; }
		[Required]
		public string Email { get; set; }
		// Add other necessary properties for trainee information
		public string TraineeId { get; set; } // Unique trainee ID
		[Required]
		[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
		[Display(Name = Message.DescriptionPassword)]
		public string Password { get; set; }
		public List<RoleViewModel> Roles { get; set; }
	}
}
