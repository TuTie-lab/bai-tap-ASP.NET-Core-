using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bai_3.Models
{
    public class PooductController : Controller
    {
        // GET: PooductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PooductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PooductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PooductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PooductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PooductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
