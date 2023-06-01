using Training_Management.Models;
using TrainingManagement.Enums;
using TrainingManagement.ViewModels;

namespace Training_Management.ViewModels
{
	public class TrainingProgrammeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        // Add other necessary properties for training program information
        public bool IsPaid { get; set; } // Flag indicating whether trainee has paid fees
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public AdvisorViewModel Advisor { get; set; }


    }
}
