using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            catch(Exception ex)
            {
                DisplayAlert("Unable to make calls at this time", "Please try again later", "OK");
            }
        }
    }
}