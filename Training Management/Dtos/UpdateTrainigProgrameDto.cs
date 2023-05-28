using System.ComponentModel.DataAnnotations;

namespace Training_Management.Dtos
{
    public class UpdateTrainigProgrameDto
    {
        public int Id { get; set; }
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
    }
}
