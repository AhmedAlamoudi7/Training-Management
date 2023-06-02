using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Training_Management.Models;

namespace Training_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

            builder.Entity<TraingProgrameTrainee>().HasOne(t => t.Trainee).WithMany(tr => tr.TraingProgrameTrainee).HasForeignKey(t => t.TraineeId);

			builder.Entity<TraingProgrameTrainee>().HasOne(t => t.TrainingProgram).WithMany(tr => tr.TraingProgrameTrainee).HasForeignKey(t => t.TrainingProgramId);


		}
		public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<Document> Documents { get; set; }
		public DbSet<Meeeting> Meeetings { get; set; }
		public DbSet<TraingProgrameTrainee> TraingProgrameTrainees { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}