using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Training_Management.Data;
namespace Training_Management.Models
{
    public class TrainingProgram : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        // Add other necessary properties for training program information
        public bool IsPaid { get; set; } // Flag indicating whether trainee has paid fees
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // Navigation properties
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }

        public List<TraingProgrameTrainee> TraingProgrameTrainee { get; set; }
    }
}
