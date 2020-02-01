using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingprovider.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateNotesPage : ContentPage
    {
        public UpdateNotesPage()
        {
            InitializeComponent();
        }
        async void Button_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Keep Up The Hard Work!", "Ok");
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
        }
    }
}