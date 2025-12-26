using Microsoft.AspNetCore.Mvc;
using _3TierArchitecture.DataAccess.Repositories;
using _3TierArchitecture.Model.Models;

namespace _3TierArchitecture.Web.Controllers
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
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repo.Add(product);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repo.Update(product);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _repo.GetById(id);
            _repo.Delete(product!);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
