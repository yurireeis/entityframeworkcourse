using System;
using System.Collections.Generic;

namespace FluentApiEfCore
{
    public class Blog
    {
        // Blog is principal in Post Relationship
        public int BlogId { get; set; } // pk
        public string Url { get; set; }
        public BlogImage BlogImage { get; set; } // reference nav prop withot BlogImageId (one-to-one)
        public ICollection<Post> Posts { get; set; } // collection navigation property
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; } // fk
        public Blog Blog { get; set; } // reference navigation property
        public ICollection<PostTag> PostTags { get; set; } // collection navigation property
    }

    public class Tag
    {
        public int TagId { get; set; }
        public ICollection<PostTag> PostTags { get; set; } // collection navigation property
    }

    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

    public class Car
    {
        public string State { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public ICollection<RecordOfSale> SaleHistory { get; set; } // collection nav prop
    }
    
    public class RecordOfSale
    {
        public int RecordOfSaleId { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }
        public string CarState { get; set; }
        public string CarLicensePlate { get; set; }
        public Car Car { get; set; } // ref nav prop
    }

    public class BlogImage
    {
        public int BlogImageId { get; set; }
        public string Url { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
