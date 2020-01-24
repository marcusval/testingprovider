
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingprovider.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
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