using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingcustomer.Views
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
            await DisplayAlert("Success", "Keep the feedback coming, we work for you!", "Ok");
            await Navigation.PopToRootAsync(); 
        }
    }
}