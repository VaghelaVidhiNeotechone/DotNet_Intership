using Azure;
using System;
using System.Collections.Generic;

namespace EfCoreMigrationsExample.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Foreign key for the one-to-many relationship
        public int BlogId { get; set; }
        // Navigation property for the one-to-many relationship
        public Blog Blog { get; set; }

        // Many-to-Many relationship: A Post has many Tags
        public ICollection<Tag> Tags { get; set; }
    }
}
