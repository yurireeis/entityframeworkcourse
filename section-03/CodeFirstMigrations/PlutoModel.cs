using System;
using System.Collections.Generic;

namespace ModelWithCodeFirstWorkflow
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public DateTime? DatePublished { get; set; }
        public ICollection<CourseTag> CourseTag { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }

    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }
        public ICollection<CourseTag> CourseTag { get; set; }
    }

    public class CourseTag
    {
        public int CourseID { get; set; }
        public int TagID { get; set; }
        public Course Course { get; set; }
        public Tag Tag { get; set; }
    }

    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Displayname { get; set; }
        public string UserName { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }
}
