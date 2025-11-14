using Microsoft.AspNetCore.Mvc;
using Validation_and_Routing.Models;

namespace Validation_and_Routing.Controllers
{
    public class ProductMvcController : Controller
    {
        private static List<Product> products = ProductsController.products;

        // GET: /ProductMvc
        public IActionResult Index()
        {
            return View(products);
        }

        // GET: /ProductMvc/Details/5
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: /ProductMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /ProductMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            product.Id = products.Count + 1;
            products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: /ProductMvc/Edit/5
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /ProductMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (!ModelState.IsValid) return View(product);

            var existing = products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.Name = product.Name;
            existing.Price = product.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: /ProductMvc/Delete/5
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
