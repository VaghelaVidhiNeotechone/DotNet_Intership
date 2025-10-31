using Shoppingapp.Models;
using ShoppingAppMVC.Models;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShoppingAppMVC.Controllers
{
    public class ShoppingsController : Controller
    {
        private ShoppingAppEntities db = new ShoppingAppEntities();

        // GET: Shoppings
        public ActionResult Index()
        {
            return View(db.Shoppings.ToList());
        }

        // GET: Shoppings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
                return HttpNotFound();

            return View(shopping);
        }

        // GET: Shoppings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shoppings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shopping shopping, HttpPostedFileBase ProductIMG)
        {
            if (ModelState.IsValid)
            {
                if (ProductIMG != null && ProductIMG.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ProductIMG.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    ProductIMG.SaveAs(path);
                    shopping.ProductIMG = "~/Images/" + fileName;
                }

                db.Shoppings.Add(shopping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopping);
        }

        // GET: Shoppings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
                return HttpNotFound();

            return View(shopping);
        }

        // POST: Shoppings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shopping shopping, HttpPostedFileBase ProductIMG)
        {
            if (ModelState.IsValid)
            {
                if (ProductIMG != null && ProductIMG.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ProductIMG.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    ProductIMG.SaveAs(path);
                    shopping.ProductIMG = "~/Images/" + fileName;
                }

                db.Entry(shopping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopping);
        }

        // GET: Shoppings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
                return HttpNotFound();

            return View(shopping);
        }

        // POST: Shoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopping shopping = db.Shoppings.Find(id);

            if (!string.IsNullOrEmpty(shopping.ProductIMG))
            {
                string imagePath = Server.MapPath(shopping.ProductIMG);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
            }

            db.Shoppings.Remove(shopping);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
