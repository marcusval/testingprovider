using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testingcustomer.Annotations;
using testingcustomer.Models;
using testingcustomer.Services;
using Newtonsoft.Json;
using Refit; 

namespace testingcustomer.ViewModels
{
    public class NextServiceViewModel : INotifyPropertyChanged

    {
        private List<NextService> _nextServiceList;

        public List<NextService> NextServiceList
        {
            get{return _nextServiceList;}
            set
            {
                _nextServiceList = value; 
                OnPropertyChanged();
            } 
        }

        public NextServiceViewModel()
        {
            InitializeDataAsync();
        }

        private async Task<List<NextService>> InitializeDataAsync()
        {
            var serviceServices = new NextServiceServices();
            NextServiceList = await serviceServices.GetListOfNextServices();
            NextServiceList.Reverse();
            return NextServiceList; 
        }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
}
