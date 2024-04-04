using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcecionarioAutomoviles.Data;
using ConcecionarioAutomoviles.Models;

namespace ConcecionarioAutomoviles.Controllers
{
    public class ServiciosOficialesController : Controller
    {
        private readonly ConcecionarioContext _context;

        public ServiciosOficialesController(ConcecionarioContext context)
        {
            _context = context;
        }

        // GET: ServiciosOficiales
        public async Task<IActionResult> Index()
        {
            var concecionarioContext = _context.ServiciosOficiales.Include(s => s.IdConcesionarioNavigation);
            return View(await concecionarioContext.ToListAsync());
        }

        // GET: ServiciosOficiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciosOficiales = await _context.ServiciosOficiales
                .Include(s => s.IdConcesionarioNavigation)
                .FirstOrDefaultAsync(m => m.IdServicioOficial == id);
            if (serviciosOficiales == null)
            {
                return NotFound();
            }

            return View(serviciosOficiales);
        }

        // GET: ServiciosOficiales/Create
        public IActionResult Create()
        {
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario");
            return View();
        }

        // POST: ServiciosOficiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicioOficial,NombreServicioOficial,DomicilioServicioOficial,Nif,IdConcesionario")] ServiciosOficiales serviciosOficiales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviciosOficiales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", serviciosOficiales.IdConcesionario);
            return View(serviciosOficiales);
        }

        // GET: ServiciosOficiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciosOficiales = await _context.ServiciosOficiales.FindAsync(id);
            if (serviciosOficiales == null)
            {
                return NotFound();
            }
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", serviciosOficiales.IdConcesionario);
            return View(serviciosOficiales);
        }

        // POST: ServiciosOficiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicioOficial,NombreServicioOficial,DomicilioServicioOficial,Nif,IdConcesionario")] ServiciosOficiales serviciosOficiales)
        {
            if (id != serviciosOficiales.IdServicioOficial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviciosOficiales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiciosOficialesExists(serviciosOficiales.IdServicioOficial))
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
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", serviciosOficiales.IdConcesionario);
            return View(serviciosOficiales);
        }

        // GET: ServiciosOficiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciosOficiales = await _context.ServiciosOficiales
                .Include(s => s.IdConcesionarioNavigation)
                .FirstOrDefaultAsync(m => m.IdServicioOficial == id);
            if (serviciosOficiales == null)
            {
                return NotFound();
            }

            return View(serviciosOficiales);
        }

        // POST: ServiciosOficiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviciosOficiales = await _context.ServiciosOficiales.FindAsync(id);
            if (serviciosOficiales != null)
            {
                _context.ServiciosOficiales.Remove(serviciosOficiales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciosOficialesExists(int id)
        {
            return _context.ServiciosOficiales.Any(e => e.IdServicioOficial == id);
        }
    }
}
