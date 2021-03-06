﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Models
{
   public class Car
    {
   
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string PhotoUrl { get; set; }

        public Double? lat { get; set; }
        public Double? Lon { get; set; }
    }
}
