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
    public class VentasController : Controller
    {
        private readonly ConcecionarioContext _context;

        public VentasController(ConcecionarioContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var concecionarioContext = _context.Ventas.Include(v => v.IdAutomovilNavigation).Include(v => v.IdServicioOficialNavigation).Include(v => v.IdVendedorNavigation);
            return View(await concecionarioContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.IdAutomovilNavigation)
                .Include(v => v.IdServicioOficialNavigation)
                .Include(v => v.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["IdAutomovil"] = new SelectList(_context.AutomovilesStocks, "NumeroBastidor", "NumeroBastidor");
            ViewData["IdServicioOficial"] = new SelectList(_context.ServiciosOficiales, "IdServicioOficial", "IdServicioOficial");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "IdVendedor", "IdVendedor");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdAutomovil,IdVendedor,IdServicioOficial,PrecioVenta,ModoPago,FechaEntrega,Matricula,EsDeStock")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutomovil"] = new SelectList(_context.AutomovilesStocks, "NumeroBastidor", "NumeroBastidor", venta.IdAutomovil);
            ViewData["IdServicioOficial"] = new SelectList(_context.ServiciosOficiales, "IdServicioOficial", "IdServicioOficial", venta.IdServicioOficial);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "IdVendedor", "IdVendedor", venta.IdVendedor);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["IdAutomovil"] = new SelectList(_context.AutomovilesStocks, "NumeroBastidor", "NumeroBastidor", venta.IdAutomovil);
            ViewData["IdServicioOficial"] = new SelectList(_context.ServiciosOficiales, "IdServicioOficial", "IdServicioOficial", venta.IdServicioOficial);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "IdVendedor", "IdVendedor", venta.IdVendedor);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdAutomovil,IdVendedor,IdServicioOficial,PrecioVenta,ModoPago,FechaEntrega,Matricula,EsDeStock")] Venta venta)
        {
            if (id != venta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.IdVenta))
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
            ViewData["IdAutomovil"] = new SelectList(_context.AutomovilesStocks, "NumeroBastidor", "NumeroBastidor", venta.IdAutomovil);
            ViewData["IdServicioOficial"] = new SelectList(_context.ServiciosOficiales, "IdServicioOficial", "IdServicioOficial", venta.IdServicioOficial);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "IdVendedor", "IdVendedor", venta.IdVendedor);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.IdAutomovilNavigation)
                .Include(v => v.IdServicioOficialNavigation)
                .Include(v => v.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.IdVenta == id);
        }
    }
}
