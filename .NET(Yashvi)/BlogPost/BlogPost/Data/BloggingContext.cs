using EfCoreMigrationsExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreMigrationsExample.Data
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // Optional: Use Fluent API for more control over relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the many-to-many relationship explicitly, though EF Core conventions often handle this
            // without needing an explicit join entity class.
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .UsingEntity(j => j.ToTable("PostTags")); // Specify a custom join table name
        }
    }
}
