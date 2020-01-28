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
namespace testingprovider.ViewModels
{
    public class MapListPageViewModel : INotifyPropertyChanged
    {
        public Map map { get; set; }
        private string providerId = App._currentProviderID;
        public List<House> _provoiderHouseList; 
        public List<MapListClass> ListOfHousesForMap; 
        public Position mapPosition;
        public Location userLocation;
        public List<Pin> pinList = new List<Pin>();


        public MapListPageViewModel()
        {
            InitializeDataAsync();
            OnAppearing();
            GetData();
        }
        public async Task<List<House>> InitializeDataAsync()
        {
            var houseService = new HouseServices();
            ProviderHouseList = await houseService.GetHousesForProvider(providerId);
            return ProviderHouseList;
        }
       
        public void GetData()
        {
            mapPosition = new Position(userLocation.Latitude, userLocation.Longitude);
            MapSpan mapSpan = new MapSpan(mapPosition, 0.1, 0.1);

            map = new Map(mapSpan);
            map.IsShowingUser = true;

           PopulatePins();
        }

        public List<House> ProviderHouseList
        {
            get { return _provoiderHouseList; }
            set
            {
                _provoiderHouseList = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

       public async void OnAppearing()
        {
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

        public void PopulatePins()
        {

            
            {
                Position position = new Position(33.567110, -117.186590);
                Pin pin = new Pin
                {
                    Label = "Via Las Lomas",
                    Address = "25084 Via Las Lomas, Murrieta",
                    Type = PinType.Place,
                    Position = position
                };
                map.Pins.Add(pin);

                Position position1 = new Position(33.660640, -117.159090);
                Pin pin1 = new Pin
                {
                    Label = "Millcreek",
                    Address = "31667 Millcreek, Menifee",
                    Type = PinType.Place,
                    Position = position1
                };
                map.Pins.Add(pin1);

                Position position2 = new Position(33.668050, -117.181170);
                Pin pin2 = new Pin
                {
                    Label = "Freedom",
                    Address = "27439 Freedom, Menifee",
                    Type = PinType.Place,
                    Position = position2
                };
                map.Pins.Add(pin2);

                Position position3 = new Position(33.688780, -117.210780);
                Pin pin3 = new Pin
                {
                    Label = "Kure",
                    Address = "25727 Kure, Menifee",
                    Type = PinType.Place,
                    Position = position3
                };
                map.Pins.Add(pin3);
            }


            if (App._currentProviderID == "4545")
            {
                Position position = new Position(33.893920, -117.467280);
                Pin pin = new Pin
                {
                    Label = "Elkwood",
                    Address = "10964 Elkwood, Riverside",
                    Type = PinType.Place,
                    Position = position
                };
                map.Pins.Add(pin);

                Position position1 = new Position(33.901440, -117.441190);
                Pin pin1 = new Pin
                {
                    Label = "Calle Loma Roja",
                    Address = "2714 Calle Loma Roja, Riverside",
                    Type = PinType.Place,
                    Position = position1
                };
                map.Pins.Add(pin1);

                Position position2 = new Position(33.957320, -117.415930);
                Pin pin2 = new Pin
                {
                    Label = "Appleton",
                    Address = "5170 Appleton, Riverside",
                    Type = PinType.Place,
                    Position = position2
                };
                map.Pins.Add(pin2);

                Position position3 = new Position(34.026371, -117.310306);
                Pin pin3 = new Pin
                {
                    Label = "Esau",
                    Address = "20326 Esau, Riverside",
                    Type = PinType.Place,
                    Position = position3
                };
                map.Pins.Add(pin3);
            }
            
        }
    }
}
