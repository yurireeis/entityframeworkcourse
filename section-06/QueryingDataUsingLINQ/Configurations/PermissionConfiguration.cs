using Microsoft.EntityFrameworkCore;
using QueryingDataUsingLINQ.Models;

namespace QueryingDataUsingLINQ.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Key);
            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired();
        }
    }
}
