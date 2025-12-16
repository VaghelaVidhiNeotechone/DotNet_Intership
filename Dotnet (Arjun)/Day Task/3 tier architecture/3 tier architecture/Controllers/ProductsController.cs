using _3_tier_architecture_DataAccess.Repositories;
using _3_tier_architecture_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3_tier_architecture.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var products = _repo.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repo.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repo.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
