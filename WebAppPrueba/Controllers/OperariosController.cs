using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPrueba.Models;
using WebAppPrueba.data;

namespace WebAppPrueba.Controllers
{
    public class OperariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Operarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Operario.ToListAsync());
        }

        // GET: Operarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Operario == null)
            {
                return NotFound();
            }

            var operario = await _context.Operario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operario == null)
            {
                return NotFound();
            }

            return View(operario);
        }

        // GET: Operarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdOperario,Nombres,Apellidos,Departamento,FechaIngreso")] Operario operario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operario);
        }

        // GET: Operarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Operario == null)
            {
                return NotFound();
            }

            var operario = await _context.Operario.FindAsync(id);
            if (operario == null)
            {
                return NotFound();
            }
            return View(operario);
        }

        // POST: Operarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdOperario,Nombres,Apellidos,Departamento,FechaIngreso")] Operario operario)
        {
            if (id != operario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperarioExists(operario.Id))
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
            return View(operario);
        }

        // GET: Operarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Operario == null)
            {
                return NotFound();
            }

            var operario = await _context.Operario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operario == null)
            {
                return NotFound();
            }

            return View(operario);
        }

        // POST: Operarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Operario == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Operario'  is null.");
            }
            var operario = await _context.Operario.FindAsync(id);
            if (operario != null)
            {
                _context.Operario.Remove(operario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperarioExists(int id)
        {
          return _context.Operario.Any(e => e.Id == id);
        }
    }
}
