using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using testingprovider.Models;
namespace testingprovider.Services
{
    public class NotesServices
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomerInterface _customerAPI;

        public NotesServices()
        {
            _httpClient = new HttpClient();
            _customerAPI = RestService.For<ICustomerInterface>("https://finalprojectapitest.azurewebsites.net/api");
        }

        public async Task<Note> PostNotesUpdate(Note notes)
        {
            return await _customerAPI.PostNotesUpdate(notes);
        }

        public async Task<List<Note>> GetAllNotes()
        {
            return await _customerAPI.GetAllNotes();
        }



        public async Task PostNotesToHouse(Note notes)
        {
            var postNotesToHouse = await _customerAPI.PostNotesToHouse(notes);

        }

    }
}
