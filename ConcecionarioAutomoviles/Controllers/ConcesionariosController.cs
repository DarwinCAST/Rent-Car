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
    public class ConcesionariosController : Controller
    {
        private readonly ConcecionarioContext _context;

        public ConcesionariosController(ConcecionarioContext context)
        {
            _context = context;
        }

        // GET: Concesionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Concesionarios.ToListAsync());
        }

        // GET: Concesionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concesionario = await _context.Concesionarios
                .FirstOrDefaultAsync(m => m.IdConcesionario == id);
            if (concesionario == null)
            {
                return NotFound();
            }

            return View(concesionario);
        }

        // GET: Concesionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concesionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConcesionario,NombreConcesionario,DomicilioConcesionario,Nif")] Concesionario concesionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concesionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concesionario);
        }

        // GET: Concesionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concesionario = await _context.Concesionarios.FindAsync(id);
            if (concesionario == null)
            {
                return NotFound();
            }
            return View(concesionario);
        }

        // POST: Concesionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConcesionario,NombreConcesionario,DomicilioConcesionario,Nif")] Concesionario concesionario)
        {
            if (id != concesionario.IdConcesionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concesionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcesionarioExists(concesionario.IdConcesionario))
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
            return View(concesionario);
        }

        // GET: Concesionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concesionario = await _context.Concesionarios
                .FirstOrDefaultAsync(m => m.IdConcesionario == id);
            if (concesionario == null)
            {
                return NotFound();
            }

            return View(concesionario);
        }

        // POST: Concesionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concesionario = await _context.Concesionarios.FindAsync(id);
            if (concesionario != null)
            {
                _context.Concesionarios.Remove(concesionario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcesionarioExists(int id)
        {
            return _context.Concesionarios.Any(e => e.IdConcesionario == id);
        }
    }
}
