using TrainingManagement.Core.Enums;
using TrainingManagement.Core.Models;
using TrainingManagement.Core.ViewModels;

namespace TrainingManagement.Core.ViewModels
{
    public class ManagerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserViewModel ApplicationUser { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }
}
