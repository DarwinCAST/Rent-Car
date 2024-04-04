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
    public class AutomovilesStocksController : Controller
    {
        private readonly ConcecionarioContext _context;

        public AutomovilesStocksController(ConcecionarioContext context)
        {
            _context = context;
        }

        // GET: AutomovilesStocks
        public async Task<IActionResult> Index()
        {
            var concecionarioContext = _context.AutomovilesStocks.Include(a => a.IdConcesionarioNavigation).Include(a => a.IdModeloNavigation);
            return View(await concecionarioContext.ToListAsync());
        }

        // GET: AutomovilesStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovilesStock = await _context.AutomovilesStocks
                .Include(a => a.IdConcesionarioNavigation)
                .Include(a => a.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.NumeroBastidor == id);
            if (automovilesStock == null)
            {
                return NotFound();
            }

            return View(automovilesStock);
        }

        // GET: AutomovilesStocks/Create
        public IActionResult Create()
        {
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario");
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo");
            return View();
        }

        // POST: AutomovilesStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroBastidor,IdModelo,IdConcesionario")] AutomovilesStock automovilesStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automovilesStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", automovilesStock.IdConcesionario);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", automovilesStock.IdModelo);
            return View(automovilesStock);
        }

        // GET: AutomovilesStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovilesStock = await _context.AutomovilesStocks.FindAsync(id);
            if (automovilesStock == null)
            {
                return NotFound();
            }
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", automovilesStock.IdConcesionario);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", automovilesStock.IdModelo);
            return View(automovilesStock);
        }

        // POST: AutomovilesStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroBastidor,IdModelo,IdConcesionario")] AutomovilesStock automovilesStock)
        {
            if (id != automovilesStock.NumeroBastidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automovilesStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomovilesStockExists(automovilesStock.NumeroBastidor))
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
            ViewData["IdConcesionario"] = new SelectList(_context.Concesionarios, "IdConcesionario", "IdConcesionario", automovilesStock.IdConcesionario);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", automovilesStock.IdModelo);
            return View(automovilesStock);
        }

        // GET: AutomovilesStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovilesStock = await _context.AutomovilesStocks
                .Include(a => a.IdConcesionarioNavigation)
                .Include(a => a.IdModeloNavigation)
                .FirstOrDefaultAsync(m => m.NumeroBastidor == id);
            if (automovilesStock == null)
            {
                return NotFound();
            }

            return View(automovilesStock);
        }

        // POST: AutomovilesStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automovilesStock = await _context.AutomovilesStocks.FindAsync(id);
            if (automovilesStock != null)
            {
                _context.AutomovilesStocks.Remove(automovilesStock);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomovilesStockExists(int id)
        {
            return _context.AutomovilesStocks.Any(e => e.NumeroBastidor == id);
        }
    }
}
