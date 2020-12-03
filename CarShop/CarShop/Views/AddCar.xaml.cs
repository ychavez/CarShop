using CarShop.Context;
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
            DataContext.Cars.Add(new Models.Car { Brand = eBrand.Text, Description = eDescription.Text, Model = eModel.Text, Price = Decimal.Parse(ePrice.Text), Year = int.Parse(eYear.Text), PhotoUrl = DataContext.IMAGE_URL }); ;
            await DisplayAlert("Agregado", "El Auto se ha agregado", "Aceptar");
            MessagingCenter.Send<Page>(this, "Update");
            await Navigation.PopAsync();
            //
        }
        private async void bMap_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GeolocatorPage());

        }
        


    }
}