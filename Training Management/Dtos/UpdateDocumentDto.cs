using System.ComponentModel.DataAnnotations;

namespace Training_Management.Dtos
{
    public class UpdateDocumentDto
    {
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Content { get; set; }
        // Add other necessary properties for document information
        public int TraineeId { get; set; }
    }
}
