using CarShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarShop.Context
{
   public class RestService
    {
        private HttpClient _client;
        private Uri _UrlBase;

        public RestService()
        {
            _UrlBase = new Uri("https://productsapidw.azurewebsites.net/");
            _client = new HttpClient();
            _client.BaseAddress = _UrlBase;
        }

        public List<Car> GetCars() {
            var response =  _client.GetAsync("api/carsForSalesApi").Result;
            if (response.IsSuccessStatusCode)
            {
                string content =  response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Car>>(content);
            }
            throw new Exception("Error al tratar de obtener la informacion del servicio web");
        }

        public void SetCars(Car car)
        {
            var json = JsonConvert.SerializeObject(car);
            var Data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync("api/carsForSalesApi", Data).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al tratar de enviar la informacion del servicio web");
            }  
        }


    }
}
