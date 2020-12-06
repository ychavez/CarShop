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
        private  MapManager gpsManager;
        public NearCars()
        {
            InitializeComponent();
            Title = "Carros cerca";
            gpsManager = new MapManager();
        }
        private async  void SetMapCars()
        {
        
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000;
            var position = await  locator.GetPositionAsync();

            Circle circle = new Circle
            {
                Center = MapManager.GetXamPosition(position),
                Radius = new Distance(2500),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromHex("#88FFC0CB")
            };
            List<Pin> pins = new List<Pin>();
            new RestService().GetCars().ForEach(x =>
            {
                if (!(x.Lon == null || x.lat == null)) pins.Add(new Pin
                { Type = PinType.SearchResult, Label = x.Model, Address = x.Description, Position = new Xamarin.Forms.Maps.Position(x.lat.Value, x.Lon.Value) });
            });

            Content = gpsManager.GetMap(true, new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), circle, pins);
            Aindicator.IsVisible = false;
            WaitText.IsVisible = false;

        }
        protected override void OnAppearing()
        {
            Aindicator.IsVisible = true;
            base.OnAppearing();
            SetMapCars();
        }
    }
}