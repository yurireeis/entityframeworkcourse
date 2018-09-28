using Microsoft.EntityFrameworkCore;

namespace CodeFirstWorkflow
{
    // DbContext is an abstraction over database
    public class BlogDbContext : DbContext
    {
        // DbSet is an abstraction over database table
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer("Server=localhost;Database=CodeFirst;User Id=sa;Password=d12DSAd12312edsadASDada@!;");
        }
    }
}
