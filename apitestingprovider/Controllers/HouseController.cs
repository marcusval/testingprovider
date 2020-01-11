using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testingproviderClassLibrary;

namespace apitestingprovider.Controllers
{
    public class HouseController : ApiController { 

        // general method to return all houses, use for testing or if you need every hosue inside the program
        public IEnumerable<House> GetAllHouses()
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                return entities.Houses.ToList();
            }
        }

        // method to get all houses belonging to a certain provider

        public IEnumerable<Route> GetRoutesForProvider(string providerID) 
        { 
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities()) 
            {
                return entities.Routes.Where(e => e.Id_P == providerID).ToList();
            }
        }

        public IEnumerable<House> GetHousesForProvider(string providerID)
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                var routeList = GetRoutesForProvider(providerID);
                var houseList = GetAllHouses();
                var HouseList = new List<House>(); 

                foreach(var value in routeList)
                {
                    foreach(var value2 in houseList)
                    {
                        if (value.Id_R.ToString() == value2.Id_R.ToString()) {
                            HouseList.Add(value2); 
                        }
                    }
                }
                return HouseList; 
            }
        }


        //use this method to show a list of all the houses belonging to a customer, use for customer application
        public IEnumerable<House> GetHouseListForCustomer(string customerID) {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities()) {
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


        public Service GetServiceForHouse(string passedHouse)
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                var houseToPass = entities.Houses.FirstOrDefault(e => e.Id_H == passedHouse);
                return entities.Services.FirstOrDefault(e => e.Id_S == houseToPass.Id_S);
            }
        }


    }
}
