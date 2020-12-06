using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopWeb.Models
{
    public class CarsForSale
    {

       [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public Double? lat { get; set; }
        public Double? Lon { get; set; }

    }
}
