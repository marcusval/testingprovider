
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials; 

namespace testingprovider.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
    
        public HomePage()
        {
            InitializeComponent();
            
        }

        async void SendText(object sender, EventArgs args)
        {
            var myVar = sender as Button;
            string names = myVar.ClassId;
            string dates = DateTime.Now.ToString();
            string message = "Hi this " + names + " just checking in, it's " + dates; 
            await SendSms(message, "9519028104"); 
        }

        async void SendOutText(object sender, EventArgs args)
        {
            var myVar = sender as Button;
            string names = myVar.ClassId;
            string dates = DateTime.Now.ToString();
            string message = "Hi this " + names + " just checking out for the day, it's " + dates;
            await SendSms(message, "9519028104");
        }

        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

    }
}