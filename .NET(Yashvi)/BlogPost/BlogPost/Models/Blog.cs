using System.Collections.Generic;

namespace EfCoreMigrationsExample.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        // One-to-Many relationship: A Blog has many Posts
        public ICollection<Post> Posts { get; set; }
    }
}
