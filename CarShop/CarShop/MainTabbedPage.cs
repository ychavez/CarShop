using CarShop.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CarShop
{
    public class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            Children.Add(new CarsForSale());
            Children.Add(new MyInfo());
            Children.Add(new SellCar());
            Title = "Sell My Car MX";
        }
    }
}
