using CarShop.Context;
using Plugin.Geolocator;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarShop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCar : ContentPage
    {
        public AddCar()
        {
            InitializeComponent();
        }
        private async void bAdd_Click(object sender, EventArgs e) {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000;


            var position = await locator.GetPositionAsync();
          
          new RestService().SetCars(new Models.Car { Brand = eBrand.Text, Description = eDescription.Text, Model = eModel.Text, Price = Decimal.Parse(ePrice.Text), Year = int.Parse(eYear.Text), PhotoUrl = DataContext.IMAGE_URL, lat = position.Latitude, Lon = position.Longitude }); 
            await DisplayAlert("Agregado", "El Auto se ha agregado", "Aceptar");
            MessagingCenter.Send<Page>(this, "Update");
            await Navigation.PopAsync();
            //
        }
        private async void bMap_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GeolocatorPage());

        }

        private async void bPhoto_Click(object sender, EventArgs e)
        {
            if (Plugin.Media.CrossMedia.Current.IsTakePhotoSupported && Plugin.Media.CrossMedia.Current.IsCameraAvailable)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { SaveToAlbum = false, SaveMetaData = false });

                if (photo != null)
                    ImgMain.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }

        }



    }
}