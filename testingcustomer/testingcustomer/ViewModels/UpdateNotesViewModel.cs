using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using testingcustomer.Annotations;
using testingcustomer.Models;
using testingcustomer.Services;
using Xamarin.Forms;

namespace testingcustomer.ViewModels
{
    public class UpdateNotesViewModel : INotifyPropertyChanged
    {
        private string HouseIdToPostNote { get; set; }
        private readonly bool _fromCustomerNote = true;
        private readonly bool _fromProviderNote = false;
        private DateTime rightNowDateTime = new DateTime();
        private Note _addedNote = new Note();
        public Note AddedNote
        {
            get { return _addedNote; }
            set
            {
                _addedNote = value;
                OnPropertyChanged();
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    AddedNote.Id_N = await GetNextId();
                    var notesServices = new NotesServices();
                    await notesServices.PostNotesUpdate(AddedNote);

                });
            }
        }

        public UpdateNotesViewModel()
        {
            HouseIdToPostNote = App._currentHouseID;
            rightNowDateTime = DateTime.Today;
            AddedNote.FromProvider = _fromProviderNote;
            AddedNote.FromCustomer = _fromCustomerNote;
            AddedNote.Id_H = HouseIdToPostNote;
            AddedNote.Ndate = rightNowDateTime;

        }


        private async Task<int> GetNextId()
        {
            int oldId;
            var notesServices = new NotesServices();
            List<Note> myList = new List<Note>();
            myList = await notesServices.GetAllNotes();
            oldId = myList.Count;
            return oldId;
        }


        //automated function to handle automatic reloading when properties on the page change
        public event PropertyChangedEventHandler PropertyChanged;

        //automated function to handle automatic reloading when properties on the page change
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
