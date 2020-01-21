using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using testingprovider.Models;
using testingprovider.Services;

namespace testingprovider.ViewModels
{
    public class SingleHouseViewModel : INotifyPropertyChanged
    {
        private string houseIDToFindSingleHouse { get; set; }
        private Service _currentHouseService;
        private House _currentHouse;
        private List<Note> _currentHouseNotes;

        //used to display a house object
        public House CurrentHouse
        {
            get { return _currentHouse; }
            set
            {
                _currentHouse = value;
                OnPropertyChanged();
            }
        }

        //function to display the notes for a house
        public List<Note> CurrentHouseNotes
        {
            get { return _currentHouseNotes; }
            set
            {
                _currentHouseNotes = value;
                OnPropertyChanged();
            }
        }

        //displays the type of landscape service the property gets, do not confuse with program service folder
        public Service CurrentHouseService
        {
            get { return _currentHouseService; }
            set
            {
                _currentHouseService = value;
                OnPropertyChanged();
            }
        }

        //constructor for the viewmodel, can my be async so must call initialize data function below. 
        public SingleHouseViewModel()
        {
            houseIDToFindSingleHouse = App._currentHouseID;
            InitializeDataAsync();

        }

        private async Task<House> InitializeDataAsync()
        {
            var viewCurrentHouseService = new HouseServices();
            CurrentHouse = await viewCurrentHouseService.GetSingleHouseDetailPage(houseIDToFindSingleHouse);
            CurrentHouseService = await viewCurrentHouseService.GetServiceForHouse(houseIDToFindSingleHouse);
            CurrentHouseNotes = await viewCurrentHouseService.GetNotesForHouse(houseIDToFindSingleHouse);
            CurrentHouseNotes.Reverse();
            return CurrentHouse;
        }


        //automated function to handle automatic reloading when properties on the page change
        public event PropertyChangedEventHandler PropertyChanged;

        //automated function to handle automatic reloading when properties on the page change
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
