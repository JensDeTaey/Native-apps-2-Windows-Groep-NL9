using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackendV7.Models.Domein
{
    public abstract class Notification
    {
        public abstract string GetTitle();
        public abstract string GetDescription();
        public abstract int GetEstablishmentId();
        public abstract int GetBusinessId();
        public abstract string GetAddedByBusinessName();
        public abstract string GetNotificationType();
        public abstract DateTime GetCreatedTime();

        public string NotifcationTitle {
            get {
                return GetTitle();
            }
        }

        public string NotificationDescription {
            get {
                return GetDescription();
            }
        }

        public int NotificationEstablishmentId {
            get {
                return GetEstablishmentId();
            }
        }

        public int NotificationBusinessId {
            get {
                return GetBusinessId();
            }
        }

        public string NotificationBusinessName {
            get {
                return GetAddedByBusinessName();
            }
        }

        public string NotificationType {
            get {
                return GetNotificationType();
            }
        }

        public DateTime NotificationCreatedTime {
            get {
                return GetCreatedTime();
            }
        }


    }
}