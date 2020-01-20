using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingcustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsefulContacts : CarouselPage
    {
        public UsefulContacts()
        {
            InitializeComponent();
        }

        private void coyphonebutton(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("9513940848");
            }
            catch (Exception ex)
            {
                DisplayAlert("Unable to make calls at this time", "Please try again later", "OK");
            }
        }

        private async void coywebsitebutton(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.coylandtechs.com/", BrowserLaunchMode.SystemPreferred);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Unable to open a browser at this time", "Please try again later", "OK");
            }
        }

        private void digphonebutton(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("811");
            }
            catch (Exception ex)
            {
                DisplayAlert("Unable to make calls at this time", "Please try again later", "OK");
            }
        }

        private async void digwebsitebutton(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.digalert.org/contact", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unable to open a browser at this time", "Please try again later", "OK");
            }
        }

        private void rachiophonebutton(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("8444722446");
            }
            catch (Exception ex)
            {
                DisplayAlert("Unable to make calls at this time", "Please try again later", "OK");
            }
        }
        private async void rachiowebsitebutton(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://rachio.com/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unable to open a browser at this time", "Please try again later", "OK");
            }
        }

        private async void pinwebsitebutton(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://www.pinterest.com/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unable to open a browser at this time", "Please try again later", "OK");
            }
        }

    }
}