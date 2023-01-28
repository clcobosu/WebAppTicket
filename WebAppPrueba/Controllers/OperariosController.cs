using System;
using System.Linq;
using WebAppPrueba.data;
using WebAppPrueba.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppPrueba.Controllers
{
    public class OperariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperariosController(ApplicationDbContext context)
        {
            _context = context;
        }

 
        public async Task<IActionResult> Index()
        {
              return View(await _context.Operario.ToListAsync());
        }

       
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

 
        public IActionResult Create()
        {
            return View();
        }

      
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
