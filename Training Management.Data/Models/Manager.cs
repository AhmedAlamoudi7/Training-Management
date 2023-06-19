
namespace Training_Management.Data
{
	public class Manager : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Add other necessary properties for manager information
        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        // Navigation properties
        public List<Trainee> Trainees { get; set; }
    }
}
