using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bai_3.Models
{
    public class CategroryController : Controller
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category() {Id =1, Name= "Laptop"},
            new Category() {Id =2, Name= "phone"},
            new Category() {Id =3, Name= "Tablet"},
        };
        // GET: CategroryController
        [HttpGet]
        public ActionResult Index()
        {

            return View(categories);
        }

        // GET: CategroryController/Details/5
        public ActionResult Details(int id)
        {
            var categrory = categories.FirstOrDefault(c => c.Id == id);
            if (categrory == null)
            {
                return NotFound();
            }

            return View(categrory);
        }

        // GET: CategroryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategroryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            category.Id = categories.Count + 1;
            categories.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategroryController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditCategory = categories.FirstOrDefault(c => c.Id == id);
            if (EditCategory == null)
            {
                return NotFound();
            }
            return View(EditCategory);
        }

        // POST: CategroryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            return RedirectToAction(nameof(Index));
        }

        // GET: CategroryController/Delete/5
        public ActionResult Delete(int id)
        {
            var caterory = categories.FirstOrDefault(c => c.Id == id);
            if (caterory == null)
            {
                return NotFound();

            }
            return View(caterory);
        }

        // POST: CategroryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var categrory = categories.FirstOrDefault(c => c.Id == id);
            if (categrory == null)
            {
                return NotFound();
            }
            else { 
                categories.Remove(categrory);
                 }
            return RedirectToAction(nameof(Index));
        } 
    }
}
