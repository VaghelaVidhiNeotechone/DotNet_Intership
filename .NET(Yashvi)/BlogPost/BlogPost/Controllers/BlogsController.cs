using EfCoreMigrationsExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreMigrationsExample.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BloggingContext _context;

        public BlogsController(BloggingContext context)
        {
            _context = context;
        }

        // GET: Blogs
        public IActionResult Index()
        {
            // Include Posts and Tags
            var blogs = _context.Blogs
                .Include(b => b.Posts)
                    .ThenInclude(p => p.Tags)
                .ToList();

            return View(blogs);
        }
    }
}
