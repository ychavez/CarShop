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
    public partial class MyInfo : ContentPage
    {
        public MyInfo()
        {
            InitializeComponent();
            Title = "Mis Favoritos";
            loadData();
        }

        private void loadData() {
            Carslist.ItemsSource = null;
            Carslist.ItemsSource = new DatabaseManager().GetFavoriteCars();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadData();
        }
    }
}