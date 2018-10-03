using UpdateObject.Configurations;
using UpdateObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace UpdateObject.context
{
    public class TestContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<UserPermission> UserPermission { get; set; }
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {new ConsoleLoggerProvider((_, __) => true, true)});
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string CONN_STRING = @"
                Server=localhost;
                Database=Test;
                User Id=sa;
                Password=d12DSAd12312edsadASDada@!;
            ";
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(CONN_STRING);
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
