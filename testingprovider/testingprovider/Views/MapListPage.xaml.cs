using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Map = Xamarin.Forms.Maps.Map;
using System.Diagnostics;
using testingprovider.Models;
using testingprovider.Services;
using System.ComponentModel;
using testingcustomer.Annotations;
using System.Runtime.CompilerServices;
using testingprovider.ViewModels;

namespace testingprovider.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MapListPage : ContentPage
   {
        public MapListPage()
        {
            InitializeComponent();


        }

    }
    
};                   
