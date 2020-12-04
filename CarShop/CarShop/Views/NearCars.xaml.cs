using CarShop.Context;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CarShop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NearCars : ContentPage
    {
        public NearCars()
        {
            InitializeComponent();
            Title = "Carros cerca";
            SetMapCars();

        }
        private async void SetMapCars() {

            Content = null;
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000;


            var position = await locator.GetPositionAsync();
            var MapPosition = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var mapSpam = MapSpan.FromCenterAndRadius(MapPosition, Distance.FromKilometers(10));
            var defaultPin = new Pin { Type = PinType.Generic, Label = "Mi ubicacion", Position = MapPosition };
            var map = new Map(mapSpam);

            map.IsShowingUser = true;
            
            //#TODO: REFACTOR AND MULTI PIND / CIRCLE OPTION

            Circle circle = new Circle
            {
                Center = MapPosition,
                Radius = new Distance(2500),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromHex("#88FFC0CB")
            };

            var vehiculos = new RestService().GetCars();
            foreach (var item in vehiculos)
            {

                if (!(item.Lon == null || item.lat == null))
                {
                    var CarPosition = new Xamarin.Forms.Maps.Position(item.lat.Value, item.Lon.Value);
                    var carPin = new Pin { Type = PinType.SearchResult, Label = item.Model, Address = item.Description, Position = CarPosition };
                    map.Pins.Add(carPin);

                }
            }

            map.MapElements.Add(circle);
            map.Pins.Add(defaultPin);
            Content = map;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetMapCars();
        }
    }
}