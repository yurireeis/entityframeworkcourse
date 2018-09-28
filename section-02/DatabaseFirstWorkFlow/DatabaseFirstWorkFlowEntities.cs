using System;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstWorkFlow
{
    public class DatabaseFirstWorkFlowEntities : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=localhost;initial catalog=course;persist security info=True;user id=sa;password=d12DSAd12312edsadASDada@!;MultipleActiveResultSets=True;App=EntityFramework;");
        }
    }
}
