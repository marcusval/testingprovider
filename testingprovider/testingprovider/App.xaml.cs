using System.Collections.Generic;
using testingprovider.Models;
using Xamarin.Forms;

namespace testingprovider
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static string _currentHouseID { get; set; }
        public static string _currentCustomerID = "132";
        public static string _currentProviderID = "3535";
        public static double _currentLat { get; set; }
        public static double _currentLong { get; set; }

    }
}
