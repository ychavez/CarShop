using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarShopWeb.Context;
using CarShopWeb.Models;

namespace CarShopWeb.Controllers
{
    public class CarsForSalesController : Controller
    {
        private readonly CarsDbContext _context;

        public CarsForSalesController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: CarsForSales
        public async Task<IActionResult> Index()
        {
            return View(await _context.carsForSales.ToListAsync());
        }

        // GET: CarsForSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsForSale = await _context.carsForSales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carsForSale == null)
            {
                return NotFound();
            }

            return View(carsForSale);
        }

        // GET: CarsForSales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarsForSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Precio,PhotoUrl")] CarsForSale carsForSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carsForSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carsForSale);
        }

        // GET: CarsForSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsForSale = await _context.carsForSales.FindAsync(id);
            if (carsForSale == null)
            {
                return NotFound();
            }
            return View(carsForSale);
        }

        // POST: CarsForSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Precio,PhotoUrl")] CarsForSale carsForSale)
        {
            if (id != carsForSale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carsForSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsForSaleExists(carsForSale.Id))
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
            return View(carsForSale);
        }

        // GET: CarsForSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsForSale = await _context.carsForSales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carsForSale == null)
            {
                return NotFound();
            }

            return View(carsForSale);
        }

        // POST: CarsForSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carsForSale = await _context.carsForSales.FindAsync(id);
            _context.carsForSales.Remove(carsForSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsForSaleExists(int id)
        {
            return _context.carsForSales.Any(e => e.Id == id);
        }
    }
}
