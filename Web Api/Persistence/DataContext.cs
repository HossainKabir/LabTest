using Domain;
using Microsoft.EntityFrameworkCore;
using Domain.Models.DB;
using Domain.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class ApplicationDataContext : IdentityDbContext<AppUser>
    {
        public ApplicationDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Value>()
                .HasData(
                new Value { Id = 1, Name = "Value-1" },
                new Value { Id = 2, Name = "Value-2" },
                new Value { Id = 3, Name = "Value-3" },
                new Value { Id = 4, Name = "Value-4" }
                );
        }
    }

    public class ApplicationDataFactory : IDesignTimeDbContextFactory<ApplicationDataContext>
    {
        public ApplicationDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>();
            optionsBuilder.UseSqlServer("Server= DESKTOP-77S3NFR\\SQLEXPRESS; Database = LabTestDB;Trusted_Connection=True; MultipleActiveResultSets=true");

            return new ApplicationDataContext(optionsBuilder.Options);
        }
    }
}
