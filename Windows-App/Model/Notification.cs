using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
    class Notification
    {
        public string NotifcationTitle { get; set; }

        public string NotificationDescription { get; set; }

        public int NotificationEstablishmentId { get; set; }

        public int NotificationBusinessId { get; set; }

        public string NotificationBusinessName { get; set; }

        public string NotificationType { get; set; }

        public DateTime NotificationCreatedTime { get; set; }

        public string Picture { get; set; }

    }
}
