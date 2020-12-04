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
            Title = "My info";
        }
    }
}