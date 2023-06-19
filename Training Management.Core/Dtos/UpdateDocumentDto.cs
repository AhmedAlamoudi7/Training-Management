using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Core.Dtos
{
    public class UpdateDocumentDto
    {
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
 
        // Add other necessary properties for document information
        public int TraineeId { get; set; }
    }
}
