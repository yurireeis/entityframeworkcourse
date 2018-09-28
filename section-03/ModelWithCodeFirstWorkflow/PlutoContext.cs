using Microsoft.EntityFrameworkCore;

namespace ModelWithCodeFirstWorkflow
{
    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer("Server=localhost;Database=CodeFirst2;User Id=sa;Password=d12DSAd12312edsadASDada@!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<CourseTag>()
              .HasKey(ct => new { ct.CourseID, ct.TagID });

          modelBuilder.Entity<CourseTag>()
              .HasOne(ct => ct.Course)
              .WithMany(ct => ct.CourseTag)
              .HasForeignKey(ct => ct.CourseID);
          
          modelBuilder.Entity<CourseTag>()
              .HasOne(ct => ct.Tag)
              .WithMany(ct => ct.CourseTag)
              .HasForeignKey(ct => ct.TagID);
        }
    }
}
