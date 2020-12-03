using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarShopWeb.Context;
using CarShopWeb.Models;

namespace CarShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsForSalesApiController : ControllerBase
    {
        private readonly CarsDbContext _context;

        public CarsForSalesApiController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: api/CarsForSalesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarsForSale>>> GetcarsForSales()
        {
            return await _context.carsForSales.ToListAsync();
        }

        // GET: api/CarsForSalesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarsForSale>> GetCarsForSale(int id)
        {
            var carsForSale = await _context.carsForSales.FindAsync(id);

            if (carsForSale == null)
            {
                return NotFound();
            }

            return carsForSale;
        }

        // PUT: api/CarsForSalesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarsForSale(int id, CarsForSale carsForSale)
        {
            if (id != carsForSale.Id)
            {
                return BadRequest();
            }

            _context.Entry(carsForSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsForSaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarsForSalesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarsForSale>> PostCarsForSale(CarsForSale carsForSale)
        {
            _context.carsForSales.Add(carsForSale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarsForSale", new { id = carsForSale.Id }, carsForSale);
        }

        // DELETE: api/CarsForSalesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarsForSale(int id)
        {
            var carsForSale = await _context.carsForSales.FindAsync(id);
            if (carsForSale == null)
            {
                return NotFound();
            }

            _context.carsForSales.Remove(carsForSale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarsForSaleExists(int id)
        {
            return _context.carsForSales.Any(e => e.Id == id);
        }
    }
}
