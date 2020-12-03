using Plugin.Geolocator;
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
    public partial class GeolocatorPage  : ContentPage
    {
    
        public  GeolocatorPage ()
        {
            try
            {
            InitializeComponent();
                 getLocation();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void getLocation()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000;


            var position = await locator.GetPositionAsync();
            var MapPosition = new Position(position.Latitude, position.Longitude);
            var mapSpam = MapSpan.FromCenterAndRadius(MapPosition, Distance.FromKilometers(10));
            var defaultPin = new Pin { Type = PinType.Place, Label = "This is my home", Position = MapPosition };
            var map = new Map(mapSpam);
            
            map.IsShowingUser = true;

            //#TODO: REFACTOR AND MULTI PIND / CIRCLE OPTION

            Circle circle = new Circle
            {
                Center = MapPosition,
                Radius = new Distance(250),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromHex("#88FFC0CB")
            };
            map.MapElements.Add(circle);
            map.Pins.Add(defaultPin);
            Content = map;


        }


    }
}