using Microsoft.AspNetCore.Http;
 
 using System.ComponentModel.DataAnnotations;
using Training_Management.Enums;
using TrainingManagement.Constants;

 namespace TrainingManagement.Core.Dtos

{
    public class UpdateAdviserDto
    {
        public int Id { get; set; }
         [Required]
        //[RegularExpression(Message.RegularExpEmail)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = Message.DescriptionEmail)]
        //[RegularExpression(Message.RegularExpEmail)]
        public string Email { get; set; }
        public string ApplicationUserId { get; set; }
        [Required]
        public DesciplineType DesciplineType { get; set; }
    }
}
