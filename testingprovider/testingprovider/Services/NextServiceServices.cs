using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using testingprovider.Models;

namespace testingprovider.Services
{
    public class NextServiceServices
    {

        private readonly HttpClient _httpClient;
        private readonly ICustomerInterface _customerAPI;

        public NextServiceServices()
        {
            _httpClient = new HttpClient();
            _customerAPI = RestService.For<ICustomerInterface>("https://finalprojectapitest.azurewebsites.net/api");
        }

        public async Task<List<NextService>> GetListOfNextServices()
        {
            return await _customerAPI.GetListOfNextServices();
        }

    }
}
