using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using testingprovider.Models;
using testingprovider.Services;

namespace testingprovider.ViewModels
{
    public class HouseViewModel : INotifyPropertyChanged
    {
        private string providerId = App._currentProviderID;
        public string houseIDToFindSingleHouse { get; set; }
        private Service _currentHouseService;
        public List<House> _provoiderHouseList;
        public Provider CurrentProvider { get; set; }

        public List<House> ProviderHouseList
        {
            get { return _provoiderHouseList; }
            set
            {
                _provoiderHouseList = value;
                OnPropertyChanged();
            }
        }

        public Service CurrentHouseService
        {
            get { return _currentHouseService; }
            set
            {
                _currentHouseService = value;
                OnPropertyChanged();
            }
        }

        public HouseViewModel()
        {
            InitializeDataAsync();
        }

        private async Task<List<House>> InitializeDataAsync()
        {
            var houseService = new HouseServices();
            ProviderHouseList = await houseService.GetHousesForProvider(providerId);
            CurrentHouseService = await houseService.GetServiceForHouse(houseIDToFindSingleHouse);
            return ProviderHouseList;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}