using Training_Management.Enums;
using Training_Management.Models;
using TrainingManagement.ViewModels;

namespace Training_Management.ViewModels
{
    public class AdvisorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public DesciplineType DesciplineType { get; set; }
        public UserViewModel ApplicationUser { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }
}
