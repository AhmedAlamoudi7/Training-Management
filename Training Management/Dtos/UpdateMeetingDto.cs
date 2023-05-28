using System.ComponentModel.DataAnnotations;

namespace Training_Management.Dtos
{
    public class UpdateMeetingDto
    {
        public int Id { get; set; }
        [Required]
        public int TraineeId { get; set; }
        [Required]
        public int AdvisorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartSession { get; set; }
        [Required]
        public DateTime EndSession { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
