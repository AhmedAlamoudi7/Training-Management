using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Training_Management.Models
{
    public class ApplicationUser : IdentityUser
    {

        //public UserType UserType { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public List<Advisor> Advisor { get; set; }
        public List<Manager> Manager { get; set; }
        public List<Trainee> Trainee { get; set; }

        public ApplicationUser()
        {
            IsDelete = false;
            CreatedAt = DateTime.Now;
        }
    }

}