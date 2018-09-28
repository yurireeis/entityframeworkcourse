
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizingFluentApiConfigs.Models;

namespace OrganizingFluentApiConfigs.EntityConfigurations
{
  public class CourseConfiguration : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      // always put table override (if exists) in the very beggining
      builder.HasKey(c => c.CourseId);
      builder.Property(c => c.Name).IsRequired();
    }
  }
}
