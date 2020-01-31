using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using testingprovider.Models;
using testingprovider.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testingprovider.ViewModels;
using System.Windows.Input;

namespace testingprovider.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private string currentProvider = App._currentProviderID; 
        
        public List<Provider> providerList = new List<Provider>(); 

        private Provider _currentProvider;
        public Provider CurrentProvider
        {
            get { return _currentProvider; }
            set
            {
                _currentProvider = value;
                OnPropertyChanged();
            }
        }
        public Action DisplayInvalidLoginPrompt;
        public bool loginvalid = false; 
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



        private async Task<List<Provider>> InitializeDataAsync()
        {
            var ProviderService = new ProviderService();
            providerList = await ProviderService.GetAllProviders();
            return providerList;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnSubmit()
        {
            foreach (var item in providerList) 
            {
                if ((email != null) && (email.Length != 0))
                {
                    if ((password != null) && (password.Length != 0))
                    {
                        if (email == item.EmailAddress) 
                        {
                            if (password == item.Password) {
                                loginvalid = true;
                                App._currentProviderID = item.Id_P; 
                                break; 
                            }
                        }
                    }
                }
            }
            if (loginvalid != true) {
                DisplayError(); 
            }
        }

        private void DisplayError() {
            DisplayInvalidLoginPrompt();
            loginvalid = false; 
            return; 
        }
    }
}
