using Microsoft.EntityFrameworkCore;
using DataAnnotations.Models;

namespace DataAnnotations.Context
{
    public class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer("Server=localhost;Database=FluentApiCore;User Id=sa;Password=d12DSAd12312edsadASDada@!;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder is fluentApi
            modelBuilder.Entity<User>()
              .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
              .Property(u => u.Name)
              .IsRequired()
              .HasMaxLength(255);
            
            // entity method: generic method to supply config for this entity
            modelBuilder.Entity<User>()
              .Property(u => u.UserName)
              .IsRequired();

            /*
              you can set a new schema name through .ToTable method
            */
            // modelBuilder.Entity<User>().ToTable("tbl_Course", "chat");

            /*
              override table name 
              (the second parameter is the name of the schema)
              modelBuilder.Entity<User>.ToTable("tbl_Course", "catalog");
            */

            /*
              HasKey set primary key
              (is used to a composite key too)
            */
            // modelBuilder.Entity<User>().HasKey(u => u.UserID);
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleID, rp.PermissionID });

            /*
              to change a column name, column type, column order, 
              is required, max lenght, just call :
                - Entity<Class>.Property.HasColumnName("{new name}")
                - Entity<Class>.Property.HasColumnType("{new type}")
                - Entity<Class>.Property.IsRequired()
                - Entity<Class>.Property.HasMaxLenght(number)
            */

            /*
              Relationships: HasMany, HasRequired, HasOptional

              HasMany: obj1 has many obj2
              HasRequired: obj1 has one obj2
              HasOptional: obj1 has zero or one obj2

              * revert direction

              WithMany: obj2 has many obj1
              WithRequired: obj2 has only one obj1
              WithOptional: obj2 has zero or one obj1

              attention to one-to-one relationship, because you must
              see who is the PRINCIPAL and who is the DEPENDENT

              modelBuilder.Entity<Course>
                  .HasRequired(course => couse.Cover)
                  .WithRequiredPrincipal(cover => cover.Course)
              
              * revert direction

              modelBuilder.Entity<Cover>
                  .HasRequired(cover => cover.Course)
                  .WithRequiredDependent(course => course.Cover)

              p.s.: cascade on delete

              if you want to Don't remove dependent object on delete
              actions, you must st WillCascadeOnDelete to false
            */
            modelBuilder.Entity<Role>()
              .HasMany(r => r.Users)
              .WithOne()
              .WillCascadeOnDelete(false);

            /*
              Property: IsRequired, HasMaxLength
            */
        }
    }
}
