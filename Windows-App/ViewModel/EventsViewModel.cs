using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    class EventsViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        public EventsViewModel()
        {
            Events = new ObservableCollection<Event>(DummyDataSource.Events);
        }
    }
}
