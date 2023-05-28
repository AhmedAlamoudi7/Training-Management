using Microsoft.Build.Framework;
using Training_Management.Models;

namespace Training_Management.Dtos
{
    public class CreateDocumentDto
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Content { get; set; }
        // Add other necessary properties for document information
        public int TraineeId { get; set; }
     }
}
