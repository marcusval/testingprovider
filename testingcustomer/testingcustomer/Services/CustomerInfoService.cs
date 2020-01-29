using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using testingcustomer.Models;


namespace testingcustomer.Services
{
    public class CustomerInfoService
    {

        private readonly HttpClient _httpClient;
        private readonly ICustomerInterface _customerAPI;

        public CustomerInfoService()
        {
            _httpClient = new HttpClient();
            _customerAPI = RestService.For<ICustomerInterface>("https://finalprojectapitest.azurewebsites.net/api");
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerAPI.GetAllCustomers();
        }

        public async Task<Customer> GetCustomerById(string ID)
        {
            return await _customerAPI.GetCustomerById(ID);
        }

    }
}
