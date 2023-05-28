using Training_Management.Models;
using TrainingManagement.Enums;
using TrainingManagement.ViewModels;

namespace Training_Management.ViewModels
{
	public class TraineeViewModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public GenderType GenderType { get; set; }
		public string Email { get; set; }
 		// Add other necessary properties for trainee information
		public string TraineeId { get; set; } // Unique trainee ID
		public UserViewModel ApplicationUser { get; set; }
		public IEnumerable<string> Roles { get; set; }
		public DateTime CreatedAt { get; set; }


	}
}
