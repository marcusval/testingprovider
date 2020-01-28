using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using testingprovider.Models;
using testingprovider.Services;


namespace testingprovider.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private string providerId = App._currentProviderID;
        public event PropertyChangedEventHandler PropertyChanged;
        private Provider _currentHouseProvider;


        public Provider CurrentProvider
        {
            get { return _currentHouseProvider; }
            set
            {
                _currentHouseProvider = value;
                OnPropertyChanged();
            }
        }

        public HomePageViewModel()
        {
            InitializeDataAsync();

        }

        private async Task<Provider> InitializeDataAsync() 
        {
            var providerDetailsService = new ProviderDetailsService();
            CurrentProvider = await providerDetailsService.GetProviderById(providerId);
            return CurrentProvider; 
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
