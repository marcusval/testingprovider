using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace testingprovider.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapListPage : ContentPage
    {
        public MapListPage()
        {
            InitializeComponent();
            Map map = new Map();
            Content = map;
        }
    }
}