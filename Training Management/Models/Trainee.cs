 using System.Reflection.Metadata;
using TrainingManagement.Enums;

namespace Training_Management.Models
{
    public class Trainee : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
		public string  LastName { get; set; }
		public GenderType GenderType { get; set; }
		public string Email { get; set; }
        public string Password { get; set; }
        // Add other necessary properties for trainee information
        public string TraineeId { get; set; } // Unique trainee ID
        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        // Navigation properties
        public List<TraingProgrameTrainee> TraingProgrameTrainee { get; set; }
        //idenetitg image
        public List<Document> Documents { get; set; }
		public List<Meeeting> Meeeting { get; set; }

	}
}
