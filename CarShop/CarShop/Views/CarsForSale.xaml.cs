using CarShop.Context;
using CarShop.Models;
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
    public partial class CarsForSale : ContentPage
    {
        public CarsForSale()
        {
            InitializeComponent();
            LoadList();
            MessagingCenter.Subscribe<Page>(this, "Update", messageCallBack);
            Title = "Comprar";
        }

        private void LoadList()
        {
            DataContext.LoadTestCars();
            Carslist.ItemsSource = null;
            Carslist.ItemsSource = new RestService().GetCars();
        }

        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            var carsSearched = new RestService().GetCars().Where(c => c.Model.ToUpper().Contains(SearchCar.Text.ToUpper()) || c.Description.ToUpper().Contains(SearchCar.Text.ToUpper()) || c.Brand.ToUpper().Contains(SearchCar.Text.ToUpper())).ToList();
            Carslist.ItemsSource = carsSearched;
        }

        void onAdd(object sender, EventArgs e) => Navigation.PushAsync(new AddCar());


        private void messageCallBack(Page obj) => LoadList();

    }
}