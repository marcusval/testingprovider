using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using testingcustomer.Models;
using testingcustomer.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testingcustomer.ViewModels;
using System.Windows.Input;
namespace testingcustomer.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
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

        public List<Customer> customerList = new List<Customer>();
        public Action DisplayInvalidLoginPrompt;
        public bool loginvalid;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginPageViewModel()
        {
            InitializeDataAsync(); 
            SubmitCommand = new Command(OnSubmit);
        }

        private async Task<List<Customer>> InitializeDataAsync()
        {
            var CustomerService = new CustomerInfoService();
            customerList = await CustomerService.GetAllCustomers();
            return customerList;
        }


        public void OnSubmit()
        {
            loginvalid = false;
            foreach (var item in customerList)
            {
                if ((email != null) && (email.Length != 0))
                {
                    if ((password != null) && (password.Length != 0))
                    {
                        if (email == item.EmailAddress)
                        {
                            if (password == item.Password)
                            {
                                loginvalid = true;
                                App._currentCustomerID = item.Id_C;
                                break;
                            }
                        }
                    }
                }
            }
            if (loginvalid != true)
            {
                DisplayError();
            }
        }

        private void DisplayError()
        {
            DisplayInvalidLoginPrompt();
            loginvalid = false;
            return;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

