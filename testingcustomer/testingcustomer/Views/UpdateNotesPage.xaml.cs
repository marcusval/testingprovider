using System;

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
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
        }
    }
}