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
        private string currentCustomer = App._currentCustomerID;
        private List<House> _customerHouseList;

        public List<House> CustomerHouseList
        {
            get { return _customerHouseList; }
            set
            {
                _customerHouseList = value;
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
            CustomerHouseList = await houseService.GetHouseListForCustomer(currentCustomer);
            return CustomerHouseList;
        }


        public event PropertyChangedEventHandler PropertyChanged;

      
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}