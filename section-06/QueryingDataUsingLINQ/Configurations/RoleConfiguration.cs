using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryingDataUsingLINQ.Models;

namespace QueryingDataUsingLINQ.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasMany(r => r.Users);
            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.Name).HasMaxLength(255).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(255).IsRequired();
        }
    }
}
