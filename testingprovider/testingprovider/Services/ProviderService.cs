using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using testingprovider.Models;

namespace testingprovider.Services
{
    public class ProviderService
    {
        public string HouseID;
        private readonly HttpClient _httpClient;
        private readonly ICustomerInterface _customerAPI;

        public ProviderService()
        {
            _httpClient = new HttpClient();
            _customerAPI = RestService.For<ICustomerInterface>("https://finalprojectapitest.azurewebsites.net/api");

        }

        
        public async Task<Service> GetServiceForHouse(string passedHouse)
        {
            return await _customerAPI.GetServiceForHouse(passedHouse);
        }
        
        public async Task<List<House>> GetHousesForProvider(string providerID)
        {
            return await _customerAPI.GetHousesForProvider(providerID);
        }


    }


    // [Get("/House?providerID={providerID}")]
    // Task<List<House>> GetHousesForProvider(string providerID);
}

