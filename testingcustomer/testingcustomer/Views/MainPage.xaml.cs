using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using testingcustomer.Views; 

namespace testingcustomer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ServiceListPage());
        }

        async void ThirdButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CustomerMain());
        }

        async void FourthButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CustomerPropertyList());
        }
    }
}
