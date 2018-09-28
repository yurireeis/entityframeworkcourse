using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryingDataUsingLINQ.Models;

namespace QueryingDataUsingLINQ.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleKey);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.RoleKey).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(255).IsRequired();
        }
    }
}
