using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingcustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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