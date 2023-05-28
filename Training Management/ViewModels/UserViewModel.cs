namespace TrainingManagement.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string? Phone { get; set; }

        //public UserType UserType { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
         public bool? EmailConfirmed { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
 
        public IEnumerable<string> Roles { get; set; }
    }
}
