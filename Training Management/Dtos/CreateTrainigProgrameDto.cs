using Microsoft.Build.Framework;
using Training_Management.Models;

namespace Training_Management.Dtos
{
    public class CreateTrainigProgrameDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        // Add other necessary properties for training program information
        [Required]
        public bool IsPaid { get; set; } // Flag indicating whether trainee has paid fees
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }

        public int AdvisorId { get; set; }
 
    }
}
