using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testingcustomer.Annotations;
using testingcustomer.Models;
using testingcustomer.Services;
using Newtonsoft.Json;
using Refit;
using testingcustomer.Views;

namespace testingcustomer.ViewModels
{
    public class SingleHouseViewModel : INotifyPropertyChanged
    {
        private string houseIDToFindSingleHouse { get; set; }
        private Service _currentHouseService;
        private House _currentHouse;

        public House CurrentHouse
        {
            get { return _currentHouse; }
            set
            {
                _currentHouse = value;
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
        public SingleHouseViewModel()
        {
            houseIDToFindSingleHouse = App._currentHouseID;
            InitializeDataAsync();
        }

        private async Task<House> InitializeDataAsync()
        {
            var viewCurrentHouseService = new HouseServices();
            CurrentHouse = await viewCurrentHouseService.GetSingleHouseDetailPage(houseIDToFindSingleHouse);
            CurrentHouseService = await viewCurrentHouseService.GetServiceForHouse(houseIDToFindSingleHouse); 
            return CurrentHouse; 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
