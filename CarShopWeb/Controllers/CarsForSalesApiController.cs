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
        public const string IMAGE_URL = "https://media.wired.com/photos/5d09594a62bcb0c9752779d9/1:1/w_1500,h_1500,c_limit/Transpo_G70_TA-518126.jpg";

        public CarsForSalesApiController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: api/CarsForSalesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarsForSale>>> GetcarsForSales()
        {
            if (_context.carsForSales.Count() == 0)
            {
                _context.carsForSales.AddRange(new List<CarsForSale>{
               new CarsForSale { Brand = "Chevrolet", Model = "Corvette", Price = 100000.1M , Year = 2010 ,Description  = "Bonito Chevrolet Corvette de 6ta generacion", PhotoUrl = IMAGE_URL },
                new CarsForSale { Brand  = "Chrysler", Model = "200", Year = 2015, Price = 120000 , Description = "Flamante  200 unico dueño", PhotoUrl = IMAGE_URL },
                new CarsForSale {  Brand = "Ford", Model = "Mustang", Year = 2018, Price = 220000, Description = "Mustang v6 en excelente estado, 40 mil km", PhotoUrl = IMAGE_URL }
                });
                _context.SaveChanges();

            }
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
