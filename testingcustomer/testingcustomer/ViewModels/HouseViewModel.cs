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


namespace testingcustomer.ViewModels
{
    public class HouseViewModel : INotifyPropertyChanged
    {
        private string currentCustomer = App._currentCustomerID; 
        private List<House> _customerHouseList;

        public List<House> CustomerHouseList
        {
            get {return _customerHouseList;}
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
