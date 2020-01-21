using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingprovider.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SinglePropertyPage : ContentPage
    {

        public SinglePropertyPage()
        {
            InitializeComponent();
        }

        async void AddNotePage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new UpdateNotesPage());
        }
    }
}