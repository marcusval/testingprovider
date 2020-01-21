using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Map = Xamarin.Forms.Maps.Map;
using System.Diagnostics;
using testingprovider.Models;
using testingprovider.Services;
using System.ComponentModel;
using testingcustomer.Annotations;
using System.Runtime.CompilerServices;

namespace testingprovider.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapListPage : ContentPage, INotifyPropertyChanged
    {
        Position mapPosition;
        Location userLocation;
        public List<Pin> pinList = new List<Pin>(); 
        private string providerId = App._currentProviderID;
        public List<House> HouseListForMap = new List<House>();
        Map map; 
        public MapListPage()
        {
            InitializeDataAsync();
            InitializeComponent();
            OnAppearing();
            mapPosition = new Position(userLocation.Latitude, userLocation.Longitude);
            MapSpan mapSpan = new MapSpan(mapPosition, 0.1, 0.1);

            map = new Map(mapSpan);
            map.IsShowingUser = true;
            PopulatePins(); 
            Content = map;
         
        }

        protected void PopulatePins()
        {
            
            Pin pin2 = new Pin
            {
                Label = "working at start",
                Address = "working at start",
                Type = PinType.Place,
                Position = new Position(33.586480, -117.108430)
            };
            map.Pins.Add(pin2);
            try
            {
                foreach (House item in HouseListForMap)
                {

                    Pin newPin = new Pin
                    {
                        Label = item.StreetName,  
                        Address = (item.StreetName + " " + item.StreetName + " " + item.StreetSuffix + ", " + item.City),
                        Type = PinType.Place,
                        Position = new Position((Convert.ToDouble(item.Lat)), (Convert.ToDouble(item.Long)))
                    };
                    map.Pins.Add(newPin);
                }

                Pin pin = new Pin
                {
                    Label = "working at end",
                    Address = "working at end",
                    Type = PinType.Place,
                    Position = new Position(33.683250, -117.175570)
                };
                map.Pins.Add(pin);

            }
            catch (Exception e) {
                Pin pin = new Pin
                {
                    Label = "Try House",
                    Address = "The city with a boardwalk",
                    Type = PinType.Place,
                    Position = new Position(33.683250, -117.175570)
                };
                map.Pins.Add(pin);
            };
        }

        private async Task<List<House>> InitializeDataAsync()
        {
            var currentHouseService = new HouseServices();
            HouseListForMap = await currentHouseService.GetHousesForProvider(providerId);
            return HouseListForMap;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await FindUserLocation();
            return; 
        }

        async Task FindUserLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                userLocation = await Geolocation.GetLastKnownLocationAsync();
                //Debug.WriteLine(userLocation?.ToString() ?? "no location");
                userLocation = await Geolocation.GetLocationAsync(request);
               // Debug.WriteLine(userLocation?.ToString() ?? "no location");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Debug.WriteLine(fnsEx);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Debug.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine(ex);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
