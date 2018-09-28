using Microsoft.EntityFrameworkCore;

namespace FluentApiEfCore
{
    public class AppContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer("Server=localhost;Database=DataAnnotations;User Id=sa;Password=d12DSAd12312edsadASDada@!;");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // set relationships manually
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts) // Posts are collection nav prop
                .WithOne(p => p.Blog) // inverse relation: Post has Blog reference nav prop
                .HasForeignKey(p => p.BlogId); // set who is the foreign key in Depentent

            // configuring composite fk
            modelBuilder.Entity<Car>()
                .HasKey(c => new { c.State, c.LicensePlate });
            
            modelBuilder.Entity<RecordOfSale>()
                .HasOne(ros => ros.Car)
                .WithMany(c => c.SaleHistory)
                .HasForeignKey(ros => new { ros.CarState, ros.CarLicensePlate });

            // many-to-many relationships
            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // one-to-one relationship
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.BlogImage)
                .WithOne(bi => bi.Blog)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
