using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Context
{
    public class DataContext
    {
        public const string IMAGE_URL = "https://media.wired.com/photos/5d09594a62bcb0c9752779d9/1:1/w_1500,h_1500,c_limit/Transpo_G70_TA-518126.jpg";
        public static List<Car> Cars { get; set; }

        public static void LoadTestCars()
        {
            if (Cars == null)
                Cars = new List<Car>{
               new Car { Id = 1, Brand = "Chevrolet", Model = "Corvette", Price = 100000.1M , Year = 2010 , Description = "Bonito Chevrolet Corvette de 6ta generacion", PhotoUrl = IMAGE_URL },
                new Car {Id = 2, Brand = "Chrysler", Model = "200", Year = 2015, Price = 120000 , Description = "Flamante  200 unico dueño", PhotoUrl = IMAGE_URL },
                new Car { Id = 2, Brand = "Ford", Model = "Mustang", Year = 2018, Price = 220000, Description = "Mustang v6 en excelente estado, 40 mil km", PhotoUrl = IMAGE_URL }
                };
        }



    }
}
