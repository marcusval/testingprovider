
using System.Collections.Generic;

using System.Linq;

using System.Web.Http;

using testingproviderClassLibrary;



namespace apitestingprovider.Controllers

{

    public class NextServicesController : ApiController

    {

        public IEnumerable<NextService> GetListOfNextServices()

        {

            using (CoyApp_dbEntities entites = new CoyApp_dbEntities())

            {

                return entites.NextServices.ToList();

            }

        }

    }

}