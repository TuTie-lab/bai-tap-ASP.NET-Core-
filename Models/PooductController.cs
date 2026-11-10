using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bai_3.Models
{
    public class PooductController : Controller
    {
        // GET: PooductController
        public static List<Pooduct> product = new List<Pooduct>()
        {
            new Pooduct () {Id=1,Name ="Laptop",Description="new laptop",Price=123400},
            new Pooduct () {Id=2,Name ="Phone",Description="new laptop",Price=123400},
            new Pooduct () {Id=3,Name ="Tablet",Description="new laptop",Price=123400}
   
        };

        public ActionResult Index()
        {
            return View(product);
        }

        // GET: PooductController/Details/5
        public ActionResult Details(int id)
        {
            var products = product.FirstOrDefault(c => c.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: PooductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PooductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pooduct products)
        {
            {
                if (ModelState.IsValid)
                {
                    products.Id = product.Count + 1;
                    product.Add(products);
                    return RedirectToAction(nameof(Index));
                }
                return View(products);
            }
        }

        // GET: PooductController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditCategory = product.FirstOrDefault(c => c.Id == id);
            if (EditCategory == null)
            {
                return NotFound();
            }
            return View(EditCategory);
        }

        // POST: PooductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pooduct products)
        {
            var existingCategory = product.FirstOrDefault(c => c.Id == products.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = products.Name;
            return RedirectToAction(nameof(Index));
        }

        // GET: PooductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PooductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var categrory = product.FirstOrDefault(c => c.Id == id);
            if (categrory == null)
            {
                return NotFound();
            }
            else
            {
                product.Remove(categrory);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
