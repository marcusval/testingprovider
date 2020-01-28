using System.Linq;

using System.Web.Http;

using testingproviderClassLibrary;





namespace apitestingprovider.Controllers

{

    public class ServiceController : ApiController

    {





        // https://localhost:44334/api/service?passedHouse=104 use this format api call to get the data to work

        public Service GetServiceForHouse(string passedHouse)

        {

            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())

            {

                var houseToPass = entities.Houses.FirstOrDefault(e => e.Id_H == passedHouse);

                return entities.Services.FirstOrDefault(e => e.Id_S == houseToPass.Id_H);

            }

        }

    }

}