using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingcustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerPropertyList : ContentPage
    {
        public CustomerPropertyList()
        {
            InitializeComponent();
        }

        async void ViewPropertyDetails(object sender, EventArgs args)
        {
            var myVar = sender as Button;
            App._currentHouseID = myVar.ClassId;
            await Navigation.PushAsync(new SinglePropertyPage());
        }
    }
}