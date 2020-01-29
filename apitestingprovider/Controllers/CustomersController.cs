using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using testingproviderClassLibrary;

namespace apitestingprovider.Controllers
{
    public class CustomersController : ApiController
    {

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                return entities.Customers.ToList();
            }
        }

        public Customer GetCustomerById(string ID)
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                return entities.Customers.FirstOrDefault(e => e.Id_C == ID);
            }
        }

        public Customer GetCustomerByEmail(string emailaddress)
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                return entities.Customers.FirstOrDefault(e => e.EmailAddress == emailaddress);
            }
        }

    }
}
