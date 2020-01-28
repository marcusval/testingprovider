using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using testingproviderClassLibrary;

namespace apitestingprovider.Controllers
{
    public class ProviderController : ApiController
    {
        public Provider GetProviderById(string ID)
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                return entities.Providers.FirstOrDefault(e => e.Id_P == ID);
            }
        }
    }
}
