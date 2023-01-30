using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerTemplateMethod.Data;
using BurgerTemplateMethod.Models;

namespace BurgerTemplateMethod.Controllers
{
    public class RancherasController : Controller
    {
        private readonly BurgerTemplateMethodContext _context;

        public RancherasController(BurgerTemplateMethodContext context)
        {
            _context = context;
        }

        // GET: Rancheras
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ranchera.ToListAsync());
        }

        // GET: Rancheras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ranchera == null)
            {
                return NotFound();
            }

            var ranchera = await _context.Ranchera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ranchera == null)
            {
                return NotFound();
            }

            return View(ranchera);
        }

        // GET: Rancheras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rancheras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ranchera ranchera)
        {
            ranchera.Name = "Hawaiana";
            ranchera.WithCheese = true;
            ranchera.Precio = 10;
            ranchera.Descripcion = "Hamburguesa de dos carnes, con huevo, queso, salchicha, tocino, vegetales";
            if (ModelState.IsValid)
            {
                _context.Add(ranchera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ranchera);
        }

        // GET: Rancheras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ranchera == null)
            {
                return NotFound();
            }

            var ranchera = await _context.Ranchera.FindAsync(id);
            if (ranchera == null)
            {
                return NotFound();
            }
            return View(ranchera);
        }

        // POST: Rancheras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio,Descripcion")] Ranchera ranchera)
        {
            if (id != ranchera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ranchera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RancheraExists(ranchera.Id))
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
            return View(ranchera);
        }

        // GET: Rancheras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ranchera == null)
            {
                return NotFound();
            }

            var ranchera = await _context.Ranchera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ranchera == null)
            {
                return NotFound();
            }

            return View(ranchera);
        }

        // POST: Rancheras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ranchera == null)
            {
                return Problem("Entity set 'BurgerTemplateMethodContext.Ranchera'  is null.");
            }
            var ranchera = await _context.Ranchera.FindAsync(id);
            if (ranchera != null)
            {
                _context.Ranchera.Remove(ranchera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RancheraExists(int id)
        {
          return _context.Ranchera.Any(e => e.Id == id);
        }
    }
}
