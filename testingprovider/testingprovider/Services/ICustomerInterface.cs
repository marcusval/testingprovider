﻿using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using testingprovider.Models;
namespace testingprovider.Services
{
    public interface ICustomerInterface
    {
        [Get("/House?providerID={providerID}")]
        Task<List<House>> GetHousesForProvider(string providerID);

        [Get("/nextservices")]
        Task<List<NextService>> GetListOfNextServices();

        [Get("/House?customerID={customerID}")]
        Task<List<House>> GetHouseListForCustomer(string customerID);

        [Get("/House/{ID}")]
        Task<House> GetSingleHouseDetailPage(string ID);

        [Get("/Customers/{ID}")]
        Task<Customer> GetCustomerById(string ID);

        [Get("/service?passedHouse={passedHouse}")]
        Task<Service> GetServiceForHouse(string passedHouse);

        [Get("/Notes?houseID={houseId}")]
        Task<List<Note>> GetNotesForHouse(string houseId);

        [Get("/Notes")]
        Task<List<Note>> GetAllNotes();

        [Post("/Notes")]
        Task<Note> PostNotesToHouse(Note newNotes);

        [Post("/Notes")]
        Task<Note> PostNotesUpdate(Note notes);
    }
}
