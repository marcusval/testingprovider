using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingcustomer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            _ = NavigateToBuilding25(); 
        }

        public async Task NavigateToBuilding25()
        {
            Location location = new Location(47.645160, -122.1306032);
            MapLaunchOptions options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            await Map.OpenAsync(location, options);
        }

    }
}