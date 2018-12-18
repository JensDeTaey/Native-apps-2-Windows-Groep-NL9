using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class NotificationsViewModel : INotifyPropertyChanged
    {

        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public List<Notification> NotificationsUnSeen { get {
                return Notifications.Where(n => !n.IsSeen).ToList();
            }
        }
        public List<Notification> NotificationsSeen {
            get {
                return Notifications.Where(n => n.IsSeen).ToList();
            }
        }

        public NotificationsViewModel()
        {
            IDataSource.singleton.FetchNotifications().ContinueWith(t =>
            {
                this.Notifications = t.Result.ToList();
                TriggerNotificationsChanged();
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void TriggerNotificationsChanged()
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("NotificationsSeen"));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("NotificationsUnSeen"));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ClearNotifications()
        {
            IDataSource.singleton.ClearNotifications().ContinueWith(t =>
            {
                if(t.Result)
                {
                    Notifications.ForEach(n => n.IsSeen = true);
                    TriggerNotificationsChanged();
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
