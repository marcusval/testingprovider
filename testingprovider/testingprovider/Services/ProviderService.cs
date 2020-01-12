using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using testingprovider.Models;
using testingprovider.Services;

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

    }
}
