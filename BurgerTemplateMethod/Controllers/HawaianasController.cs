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
    public class HawaianasController : Controller
    {
        private readonly BurgerTemplateMethodContext _context;

        public HawaianasController(BurgerTemplateMethodContext context)
        {
            _context = context;
        }

        // GET: Hawaianas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Hawaiana.ToListAsync());
        }

        // GET: Hawaianas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hawaiana == null)
            {
                return NotFound();
            }

            var hawaiana = await _context.Hawaiana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hawaiana == null)
            {
                return NotFound();
            }

            return View(hawaiana);
        }

        // GET: Hawaianas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hawaianas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Hawaiana hawaiana)
        {
            hawaiana.Name = "Hawaiana";
            hawaiana.WithCheese = false;
            hawaiana.Precio = 7;
            hawaiana.Descripcion = "Hamburguesa de una carne, con pina, y mermelada";
            if (ModelState.IsValid)
            {
                _context.Add(hawaiana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hawaiana);
        }

        // GET: Hawaianas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hawaiana == null)
            {
                return NotFound();
            }

            var hawaiana = await _context.Hawaiana.FindAsync(id);
            if (hawaiana == null)
            {
                return NotFound();
            }
            return View(hawaiana);
        }

        // POST: Hawaianas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese,Precio,Descripcion")] Hawaiana hawaiana)
        {
            if (id != hawaiana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hawaiana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HawaianaExists(hawaiana.Id))
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
            return View(hawaiana);
        }

        // GET: Hawaianas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hawaiana == null)
            {
                return NotFound();
            }

            var hawaiana = await _context.Hawaiana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hawaiana == null)
            {
                return NotFound();
            }

            return View(hawaiana);
        }

        // POST: Hawaianas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hawaiana == null)
            {
                return Problem("Entity set 'BurgerTemplateMethodContext.Hawaiana'  is null.");
            }
            var hawaiana = await _context.Hawaiana.FindAsync(id);
            if (hawaiana != null)
            {
                _context.Hawaiana.Remove(hawaiana);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HawaianaExists(int id)
        {
          return _context.Hawaiana.Any(e => e.Id == id);
        }
    }
}
