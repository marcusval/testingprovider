using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testingcustomer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingcustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static readonly Xamarin.Forms.BindableProperty HasBackButtonProperty;
        public LoginPage()
        {
            InitializeComponent();
            var vms = new LoginPageViewModel();
            this.BindingContext = vms;
            vms.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");


            emailentry.Completed += (object sender, EventArgs e) =>
            {
                passwordentry.Focus();
            };

            passwordentry.Completed += (object sender, EventArgs e) =>
            {

                vms.SubmitCommand.Execute(null);
                if (vms.loginvalid)
                {
                    CheckLogin();
                }
            };
        }

        async void CheckLogin()
        {
            await Navigation.PushAsync(new MainPage());
        }

        void CheckLoginClicked(object sender, EventArgs args)
        {

        }
    }
}