﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testingcustomer.Models;
using testingcustomer.Services;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testingcustomer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceListPage : ContentPage
    {
        public ServiceListPage()
        {
            InitializeComponent();
        }
    }
}