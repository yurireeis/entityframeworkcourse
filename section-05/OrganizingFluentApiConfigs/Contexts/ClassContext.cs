using Microsoft.EntityFrameworkCore;
using OrganizingFluentApiConfigs.EntityConfigurations;

namespace OrganizingFluentApiConfigs.Contexts
{
    public class ClassContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=OrganizedFluentAPI;User Id=sa;Password=d12DSAd12312edsadASDada@!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
