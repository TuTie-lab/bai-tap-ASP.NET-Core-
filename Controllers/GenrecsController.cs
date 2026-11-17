using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tu_day6_2.Data;
using Tu_day6_2.Models;

namespace Tu_day6_2.Controllers
{
    public class GenrecsController : Controller
    {
        private readonly Tu_day6_2Context _context;

        public GenrecsController(Tu_day6_2Context context)
        {
            _context = context;
        }

        // GET: Genrecs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genrecs.ToListAsync());
        }

        // GET: Genrecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genrecs = await _context.Genrecs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genrecs == null)
            {
                return NotFound();
            }
            return View(genrecs);
        }

        // GET: Genrecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genrecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Genrecs genrecs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genrecs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genrecs);
        }

        // GET: Genrecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {  
            if (id == null)
            {
                return NotFound();
            }

            var genrecs = await _context.Genrecs.FindAsync(id);
            if (genrecs == null)
            {
                return NotFound();
            }
            return View(genrecs);
        }

        // POST: Genrecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Genrecs genrecs)
        {
            if (id != genrecs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genrecs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenrecsExists(genrecs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genrecs);
        }

        // GET: Genrecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genrecs = await _context.Genrecs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genrecs == null)
            {
                return NotFound();
            }

            return View(genrecs);
        }

        // POST: Genrecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genrecs = await _context.Genrecs.FindAsync(id);
            if (genrecs != null)
            {
                _context.Genrecs.Remove(genrecs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenrecsExists(int id)
        {
            return _context.Genrecs.Any(e => e.Id == id);
        }
    }
}
