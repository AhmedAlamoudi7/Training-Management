using Microsoft.Build.Framework;
using Training_Management.Models;

namespace Training_Management.Dtos
{
    public class CreateDocumentDto
    {
        [Required]
        public IFormFile FileName { get; set; }
 
        // Add other necessary properties for document information
        public int TraineeId { get; set; }
     }
}
