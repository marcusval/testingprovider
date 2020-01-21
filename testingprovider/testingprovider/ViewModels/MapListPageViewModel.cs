﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using testingprovider.Models;
using testingprovider.Services;

namespace testingprovider.ViewModels
{
    public class MapListPageViewModel : INotifyPropertyChanged
    {
        private string providerId;
        public List<House> HouseListForMaps = new List<House>();

        public MapListPageViewModel()
        {
            providerId = App._currentProviderID;
            InitializeDataAsync();


        }


        private async Task<List<House>> InitializeDataAsync()
        {
            var currentHouseService = new HouseServices();
            HouseListForMaps = await currentHouseService.GetHousesForProvider(providerId);
            return HouseListForMaps;
        }







        public event PropertyChangedEventHandler PropertyChanged;
    }
}
