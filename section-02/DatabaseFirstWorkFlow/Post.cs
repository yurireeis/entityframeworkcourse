using System;

namespace DatabaseFirstWorkFlow
{
    public partial class Post
    {
        public int PostID { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
