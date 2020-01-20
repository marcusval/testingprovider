using Refit;
using System.Net.Http;
using System.Threading.Tasks;
using testingprovider.Models;
namespace testingprovider.Services
{
    public class CustomerDetailsService
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomerInterface _customerAPI;

        public CustomerDetailsService()
        {
            _httpClient = new HttpClient();
            _customerAPI = RestService.For<ICustomerInterface>("https://finalprojectapitest.azurewebsites.net/api");
        }

        public async Task<Customer> GetCustomerById(string ID)
        {
            return await _customerAPI.GetCustomerById(ID);
        }
    }
}
