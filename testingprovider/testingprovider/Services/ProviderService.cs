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

        public async Task<Provider> GetProviderByEmail(string email)
        {
            return await _customerAPI.GetProviderByEmail(email); 
        }

        public async Task<List<Provider>> GetAllProviders()
        {
            return await _customerAPI.GetAllProviders();
        }



    }


    // [Get("/House?providerID={providerID}")]
    // Task<List<House>> GetHousesForProvider(string providerID);
}

