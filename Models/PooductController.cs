using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bai_3.Models
{
    public class PooductController : Controller
    {
        //GET: PooductController
        public static List<Pooduct> product = new List<Pooduct>()
        {
            //new Pooduct () {Id=1,Name ="Laptop",Description="new laptop",Price=123400},
            //new Pooduct () {Id=2,Name ="Phone",Description="new laptop",Price=123400},
            //new Pooduct () {Id=3,Name ="Tablet",Description="new laptop",Price=123400}

        };

        //public ActionResult Index(string? searchString)
        //{
        //    var product = Data.product.AsQueryable();
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        product = product.Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        //    }
        //    return View(product.Select(ToViewModle).ToList());
        //}
        // GET: Pooduct
        //public IActionResult Index(string? searchString, string? sortOrder)
        //{
        //    // 1. Lưu lại từ khóa tìm kiếm và tiêu chí sắp xếp ra ViewBag để hiển thị lại trên View nếu cần
        //    ViewBag.CurrentFilter = searchString;
        //    ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

        //    // 2. Chuyển List thành IQueryable để thực hiện lọc và sắp xếp
        //    var products = product.AsQueryable();

        //    // 3. Xử lý Tìm kiếm (nếu người dùng nhập từ khóa)
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        products = products.Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        //    }

        //    // 4. Xử lý Sắp xếp
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            products = products.OrderByDescending(p => p.Name);
        //            break;
        //        case "Price":
        //            products = products.OrderBy(p => p.Price);
        //            break;
        //        case "price_desc":
        //            products = products.OrderByDescending(p => p.Price);
        //            break;
        //        default: 
        //            products = products.OrderBy(p => p.Name);
        //            break;
        //    }
        //    return View(products.ToList());
        //}
        // GET: Pooduct
        public IActionResult Index(string? searchString, string? sortOrder, int page = 1, int pageSize = 5)
        {
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            var products = product.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }
            int totalItems = products.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var pagedProducts = products
                                .Skip((page - 1) * pageSize) 
                                .Take(pageSize)             
                                .ToList();

            return View(pagedProducts);
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
            ViewBag.CategroryId = new SelectList(Data.Data.Categrories, "CategroryId", "CategroryName");
            return View();
        }

        // POST: PooductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Pooduct products)
        {
            {
                if (ModelState.IsValid)
                {
                    products.Id = Data.Data.product.Max(p => p.Id) + 1;
                   Data.Data. product.Add(products);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.CategroryId = new SelectList(Data.Data.categories, "CategroryId", "CategroryName");
                return View(products);
            }
        }

        // GET: PooductController/Edit/5
        public ActionResult Edit(int id)
        {
            var products =Data.Data product.FirstOrDefault(c => c.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            ViewBag.CategroryId = new SelectList(Data.Data.categories, "CategroryId", "CategroryName");
            return View(products);
        }

        // POST: PooductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Pooduct Editproducts)
        {
            var products = Data.Data.product.FirstOrDefault(c => c.Id == product.Id==Editproducts.Id);
            if (products == null)
            {
                return NotFound();
            }
            products.Name = products.Name;
            products.Price = products.Price;
            products.Id = products.Id;
            ViewBag.CategroryId = new SelectList(Data.Data.categories, "CategroryId", "CategroryName");
            return RedirectToAction(Editproducts);
        }

        // GET: PooductController/Delete/5
        public ActionResult Delete(int id)
        {
            var products = Data.Data product.FirstOrDefault(c => c.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            ViewBag.CategroryId = new SelectList(Data.Data.categories, "CategroryId", "CategroryName");

            return View();
        }

        // POST: PooductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var products = Data.Data. product.FirstOrDefault(c => c.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            else
            {
               Data.product.Remove(categrory);
            }
            return RedirectToAction(nameof(Index));

        }
        private static Pooduct ToViewModle (Pooduct products)
        {
            return new Pooduct
            {
                Id = products.Id,
                Name = products.Name,
                Decription = products.Description,
                Price = products.Price,
                CategroryName = Data.categories.FisrtOrDefault(c => c.id == products.CategroryId)?.Name ?? string.Empty
            };
        }
    }
}
