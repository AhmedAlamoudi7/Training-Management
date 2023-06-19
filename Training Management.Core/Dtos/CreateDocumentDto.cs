using Microsoft.Build.Framework;
using Training_Management.Models;

namespace TrainingManagement.Core.Dtos
{
    public class CreateDocumentDto
    {
        [Required]
        public IFormFile FileName { get; set; }
 
        // Add other necessary properties for document information
        public int TraineeId { get; set; }
     }
}
