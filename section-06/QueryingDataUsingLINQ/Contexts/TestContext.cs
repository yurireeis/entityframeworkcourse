using Microsoft.EntityFrameworkCore;
using QueryingDataUsingLINQ.Configurations;
using QueryingDataUsingLINQ.Models;

namespace QueryingDataUsingLINQ.Contexts
{
    public class TestContext : DbContext
    {

        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserPermission> UserPermission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string CONN_STRING = @"
                Server=localhost;
                Database=Test;
                User Id=sa;
                Password=d12DSAd12312edsadASDada@!;
            ";
            optionsBuilder.UseSqlServer(CONN_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        }
    }
}
