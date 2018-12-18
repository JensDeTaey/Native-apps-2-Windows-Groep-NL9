using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
    public class Notification
    {
        public string NotifcationTitle { get; set; }

        public string NotificationDescription { get; set; }

        public int NotificationEstablishmentId { get; set; }

        public int NotificationBusinessId { get; set; }

        public string NotificationBusinessName { get; set; }

        public string NotificationEstablishmentName { get; set; }

        public string NotificationType { get; set; }

        public DateTime NotificationCreatedTime { get; set; }

        public string Picture { get; set; }

        public bool IsSeen { get; set; }


        public string FirstLine {
            get {
                string prefix = "";
                switch(NotificationType)
                {
                    case "EVENT":
                        prefix = "Nieuw event: ";
                        break;
                    case "PROMOTION":
                        prefix = "Nieuwe promotie: ";
                        break;
                }
               
                return prefix + NotifcationTitle;
            }
        }

        public string SecondLine {
            get {
                return NotificationDescription;
            }
        }

        public string ThirdLine {
            get {
                return NotificationCreatedTime.ToString() + " - " + NotificationBusinessName + " - " + NotificationEstablishmentName;
            }
        }

    }
}
