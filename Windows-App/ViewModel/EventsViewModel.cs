using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    class EventsViewModel : INotifyPropertyChanged
    {
        private Collection<Event> SortedAllEvents { get; set; }
        private ObservableCollection<Event> events;

        public ObservableCollection<Event> Events
        {
            get { return events; }
            set
            {
                events = value;
                HasNoItems = events.Count > 0;
                NotifyPropertyChanged();
            }
        }

        private bool hasNoItems;
        public bool HasNoItems
        {
            get
            {
                return hasNoItems;
            }
            set
            {
                if (hasNoItems != value)
                {
                    hasNoItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public EventsViewModel()
        {
            SortedAllEvents = new Collection<Event>();
            events = new ObservableCollection<Event>();
            IDataSource.singleton.FetchEvents().ContinueWith(t =>
            {
                if (t.Result != null)
                {
                    SortedAllEvents = t.Result;
                    Events = t.Result;
                    SortEventsByStartDate(false);
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void SortEventsByStartDate(bool ascending)
        {
            //Filter on startDate
            List<Event> sortedAllEvents = SortedAllEvents.OrderBy(e => e.StartDate).ToList();
            if (ascending)
                sortedAllEvents.Reverse();
            SortedAllEvents = new ObservableCollection<Event>(sortedAllEvents);
            //Sort the filtered list
            List<Event> sortedEvents = Events.OrderBy(e => e.StartDate).ToList();
            if (ascending)
                sortedEvents.Reverse();
            Events = new ObservableCollection<Event>(sortedEvents);
        }

        public void SortEventsByEndDate(bool ascending)
        {
            //Filter on startDate
            List<Event> sortedAllEvents = SortedAllEvents.OrderBy(e => e.EndDate).ToList();
            if (ascending)
                sortedAllEvents.Reverse();
            SortedAllEvents = new ObservableCollection<Event>(sortedAllEvents);
            //Sort the filtered list
            List<Event> sortedEvents = Events.OrderBy(e => e.EndDate).ToList();
            if (ascending)
                sortedEvents.Reverse();
            Events = new ObservableCollection<Event>(sortedEvents);
        }

        public void FilterEvents(string filter)
        {
           //Filter on event name and on description
            Events = new ObservableCollection<Event>(SortedAllEvents.Where(e =>
                e.Name.ToLower().Contains(filter.ToLower()) ||
                e.Description.ToLower().Contains(filter.ToLower())
            ));
        }

    }
}
