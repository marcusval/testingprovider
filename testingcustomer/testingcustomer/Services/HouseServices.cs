﻿using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using testingcustomer.Models;


namespace testingcustomer.Services
{
    public class HouseServices
    {
        public string HouseID;
        private readonly HttpClient _httpClient;
        private readonly ICustomerInterface _customerAPI;

        public HouseServices()
        {
            _httpClient = new HttpClient();
            _customerAPI = RestService.For<ICustomerInterface>("https://finalprojectapitest.azurewebsites.net/api");

        }

        public async Task<List<House>> GetHouseListForCustomer(string customerID)
        {
            return await _customerAPI.GetHouseListForCustomer(customerID);
        }

        public async Task<House> GetSingleHouseDetailPage(string ID)
        {
            return await _customerAPI.GetSingleHouseDetailPage(ID);
        }

        public async Task<Service> GetServiceForHouse(string passedHouse)
        {
            return await _customerAPI.GetServiceForHouse(passedHouse);
        }

        public async Task<List<Note>> GetNotesForHouse(string houseId)
        {
            return await _customerAPI.GetNotesForHouse(houseId);
        }
    }
}
