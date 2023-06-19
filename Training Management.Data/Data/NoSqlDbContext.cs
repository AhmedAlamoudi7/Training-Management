using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Training_Management.Data;

namespace Training_Management.Data
{
    public class NoSqlDbContext : IdentityDbContext
    {
        public NoSqlDbContext(DbContextOptions<NoSqlDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Document> Documents { get; set; }

    }
}