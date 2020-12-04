using CarShopWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopWeb.Context
{
    public class CarsDbContext: DbContext
    {

        public CarsDbContext(DbContextOptions<CarsDbContext> options)
           : base(options)
        {


        }
        public DbSet<CarsForSale> carsForSales { get; set; }
    }
}
