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
    public partial class GeolocatorPage : ContentPage
    {

        public GeolocatorPage()
        {

            InitializeComponent();
            getLocation();

        }


        private async void getLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000;
            var position = await locator.GetPositionAsync();
            Content = new MapManager().GetMap(true, MapManager.GetXamPosition(position));
        }


    }
}