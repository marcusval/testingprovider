using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using testingcustomer.Models;
using testingcustomer.Services;


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
    }
}
