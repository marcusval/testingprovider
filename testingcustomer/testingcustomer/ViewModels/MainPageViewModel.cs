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
    public class MainPageViewModel : INotifyPropertyChanged
    {

        private string currentCustomer = App._currentCustomerID;
        private Customer _currentCustomer; 

        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel() {
            InitializeDataAsync();
        }

        private async Task<Customer> InitializeDataAsync()
        {
            var CustomerService = new CustomerDetailsService();
            CurrentCustomer = await CustomerService.GetCustomerById(currentCustomer);
            return CurrentCustomer; 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
