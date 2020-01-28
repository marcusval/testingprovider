using Refit;
using System.Net.Http;
using System.Threading.Tasks;
using testingprovider.Models;

namespace testingprovider.Services
{
    public class ProviderDetailsService
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomerInterface _providerAPI;

        public ProviderDetailsService()
        {
            _httpClient = new HttpClient();
            _providerAPI = RestService.For<ICustomerInterface>("https://finalprojectapitest.azurewebsites.net/api");
        }

        public async Task<Provider> GetProviderById(string ID)
        {
            return await _providerAPI.GetProviderById(ID);
        }
    }
}
