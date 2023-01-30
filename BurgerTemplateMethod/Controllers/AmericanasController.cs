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
    public class AmericanasController : Controller
    {
        private readonly BurgerTemplateMethodContext _context;

        public AmericanasController(BurgerTemplateMethodContext context)
        {
            _context = context;
        }

        // GET: Americanas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Americana.ToListAsync());
        }

        // GET: Americanas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Americana == null)
            {
                return NotFound();
            }

            var americana = await _context.Americana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (americana == null)
            {
                return NotFound();
            }

            return View(americana);
        }

        // GET: Americanas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Americanas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,WithCheese,Precio, Descripcion")] Americana americana)
        {
            americana.Name = "Americana";
            americana.WithCheese = true;
            americana.Precio = 9;
            americana.Descripcion = "Hamburguesa con tocino, doble carne, queso cheddar, cebolla crispy, lechuga y cebolla";

            if (ModelState.IsValid)
            {
                _context.Add(americana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(americana);
        }

        // GET: Americanas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Americana == null)
            {
                return NotFound();
            }

            var americana = await _context.Americana.FindAsync(id);
            if (americana == null)
            {
                return NotFound();
            }
            return View(americana);
        }

        // POST: Americanas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio")] Americana americana)
        {
            if (id != americana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(americana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmericanaExists(americana.Id))
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
            return View(americana);
        }

        // GET: Americanas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Americana == null)
            {
                return NotFound();
            }

            var americana = await _context.Americana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (americana == null)
            {
                return NotFound();
            }

            return View(americana);
        }

        // POST: Americanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Americana == null)
            {
                return Problem("Entity set 'BurgerTemplateMethodContext.Americana'  is null.");
            }
            var americana = await _context.Americana.FindAsync(id);
            if (americana != null)
            {
                _context.Americana.Remove(americana);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmericanaExists(int id)
        {
          return _context.Americana.Any(e => e.Id == id);
        }
    }
}
