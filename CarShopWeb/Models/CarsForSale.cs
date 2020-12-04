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
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
        public int Año { get; set; }
        public string Descripcion { get; set; }
        public string PhotoUrl { get; set; }
        public float? lat { get; set; }
        public float? Lon { get; set; }

    }
}
