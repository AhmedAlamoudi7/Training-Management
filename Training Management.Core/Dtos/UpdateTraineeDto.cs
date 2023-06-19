using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;
using TrainingManagement.Enums;
using TrainingManagement.ViewModels;

namespace TrainingManagement.Core.Dtos
{
	public class UpdateTraineeDto
	{
		public int Id { get; set; }
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
        public string ApplicationUserId { get; set; }



    }
}
