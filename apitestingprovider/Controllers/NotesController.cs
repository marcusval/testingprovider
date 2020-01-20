using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using testingproviderClassLibrary;

namespace apitestingprovider.Controllers
{
    public class NotesController : ApiController
    {
        //use as a general method for getting all notes in the system
        public IEnumerable<Note> GetAllNotes()
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                return entities.Notes.ToList();
            }
        }

        //Method to get the notes that belong to one house, use on property detail page
        public IEnumerable<Note> GetNotesForHouse(string houseID)
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                return entities.Notes.Where(e => e.Id_H == houseID).ToList();

            }
        }

        public void PostNotesUpdate([FromBody] Note notes)
        {
            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())
            {
                entities.Notes.Add(notes);
                entities.SaveChanges();
            }
        }
    }
}
