using System.Collections.Generic;

using System.Linq;

using System.Web.Http;

using testingproviderClassLibrary;



namespace apitestingprovider.Controllers

{

    public class HouseController : ApiController

    {



        // general method to return all houses, use for testing or if you need every hosue inside the program

        public IEnumerable<House> GetAllHouses()

        {

            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())

            {

                return entities.Houses.ToList();

            }

        }

        //use url style below when making a call to test function in api, 3535 is a provider ID number  

        //https://finalprojectapitest.azurewebsites.net/api/House?providerID=3535

        //function to get a List of houses that belong to a provider, will list all houses on every route that the provider services.

        public IEnumerable<House> GetHousesForProvider(string providerID)

        {

            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())

            {

                List<Route> routeList = entities.Routes.Where(e => e.Id_P == providerID).ToList();

                List<House> houseList = entities.Houses.ToList();

                List<House> HouseLists = new List<House>();



                foreach (Route routevalue in routeList)

                {

                    foreach (House housevalue in houseList)

                    {

                        if ((routevalue.Id_R.ToString()) == (housevalue.Id_R))

                        {

                            HouseLists.Add(housevalue);

                        }

                    }

                }

                return HouseLists;

            }

        }

        public List<House> GetHousesForMap(string provider)

        {

            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())

            {

                List<Route> routeList = entities.Routes.Where(e => e.Id_P == provider).ToList();

                List<House> houseList = entities.Houses.ToList();

                List<House> HouseLists = new List<House>();



                foreach (Route routevalue in routeList)

                {

                    foreach (House housevalue in houseList)

                    {

                        if ((routevalue.Id_R.ToString()) == (housevalue.Id_R))

                        {

                            HouseLists.Add(housevalue);

                        }

                    }

                }

                return HouseLists;

            }

        }


        //use this method to show a list of all the houses belonging to a customer, use for customer application
        public IEnumerable<House> GetHouseListForCustomer(string customerID)

        {

            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())

            {

                return (entities.Houses.Where(e => e.Id_C == customerID).ToList());

            }

        }

        //use this method for returning the detail page of a single house. To see the notes use the notes 
        // controller request for calling a particular house
        public House GetSingleHouseDetailPage(string ID)

        {

            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())

            {

                return entities.Houses.FirstOrDefault(e => e.Id_H == ID);

            }

        }

        //public IEnumerable<House> GetHouseListForProvider(string providerID){}

    }

}