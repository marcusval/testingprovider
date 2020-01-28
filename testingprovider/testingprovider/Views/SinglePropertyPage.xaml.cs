using System;
using Xamarin.Essentials; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testingprovider.ViewModels; 

namespace testingprovider.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SinglePropertyPage : ContentPage
    {

        public SinglePropertyPage()
        {
            InitializeComponent();
        }

        async void AddNotePage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new UpdateNotesPage());
        }

        async void GoToNotePage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NotesPage());
        }

        async void GoToDirectionsPage(object sender, EventArgs args)
        {
            var vm = BindingContext as SingleHouseViewModel;
            string lat = vm.CurrentHouse.Lat;
            double lattouse = Convert.ToDouble(lat);
            string longs = vm.CurrentHouse.Long;
            double logtouse = Convert.ToDouble(longs);
            string names = vm.CurrentHouse.StreetName; 

            Location location = new Location(lattouse, logtouse);
            MapLaunchOptions options = new MapLaunchOptions { Name =  names};

            await Map.OpenAsync(location, options);
        }
    }
}