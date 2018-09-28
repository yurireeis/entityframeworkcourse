using System;

namespace DatabaseFirstWorkFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            // use db context to work with database
            DatabaseFirstWorkFlowEntities context = new DatabaseFirstWorkFlowEntities();
            Post post = new Post() {
                PostID = 1,
                Body = "Textão do face",
                Title = "#elenao",
                DatePublished = DateTime.Now
            };

            // add the post and save the changes
            context.Posts.Add(post); // only in memory
            context.SaveChanges();
        }
    }
}
