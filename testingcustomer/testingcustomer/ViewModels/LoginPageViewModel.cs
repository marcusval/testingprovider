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
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (email != "hello" || password != "hello")
            {
                DisplayInvalidLoginPrompt();
                loginvalid = false;
            }
            else { loginvalid = true; }

        }
    }
}

