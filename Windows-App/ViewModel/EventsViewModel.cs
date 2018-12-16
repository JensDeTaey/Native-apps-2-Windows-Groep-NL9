using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    class EventsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Event> Events { get; set; }
        public EventsViewModel()
        {
            IDataSource.singleton.FetchEvents().ContinueWith(t =>
            {
                this.Events = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Events"));
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
