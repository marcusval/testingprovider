using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Newtonsoft.Json;
using testingcustomer.Models;

namespace testingcustomer.Services
{
    public interface ICustomerInterface
    {
        [Get("/nextservices")]
        Task<List<NextService>> GetListOfNextServices();

        [Get("/House?customerID={customerID}")]
        Task<List<House>> GetHouseListForCustomer(string customerID);

        [Get("/House/{ID}")]
        Task<House> GetSingleHouseDetailPage(string ID);

        [Get("/service?passedHouse={passedHouse}")]
        Task<Service> GetServiceForHouse(string passedHouse);
    }
}
