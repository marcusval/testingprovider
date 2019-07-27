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
    }
}
