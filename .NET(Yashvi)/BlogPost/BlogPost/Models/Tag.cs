using System.Collections.Generic;

namespace EfCoreMigrationsExample.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        // Many-to-Many relationship: A Tag has many Posts
        public ICollection<Post> Posts { get; set; }
    }
}
