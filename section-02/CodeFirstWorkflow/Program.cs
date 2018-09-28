using System;

namespace CodeFirstWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlogDbContext db = new BlogDbContext())
            {
                db.Posts.Add(new Post() {
                    Id = 1, DatePublished = DateTime.Now, Title = "#elesim", Body = "Tiro porrada e bomba"
                });
                db.SaveChangesAsync();
            }
        }
    }
}
