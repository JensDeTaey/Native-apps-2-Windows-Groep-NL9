using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackendV7.Models.Domein
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Notification
    {
        public abstract string GetTitle();
        public abstract string GetDescription();
        public abstract int GetEstablishmentId();
        public abstract int GetBusinessId();
        public abstract string GetAddedByBusinessName();
        public abstract string GetNotificationType();
        public abstract DateTime GetCreatedTime();

        [JsonProperty]
        public string NotifcationTitle {
            get {
                return GetTitle();
            }
        }
        [JsonProperty]
        public string NotificationDescription {
            get {
                return GetDescription();
            }
        }
        [JsonProperty]
        public int NotificationEstablishmentId {
            get {
                return GetEstablishmentId();
            }
        }
        [JsonProperty]
        public int NotificationBusinessId {
            get {
                return GetBusinessId();
            }
        }
        [JsonProperty]
        public string NotificationBusinessName {
            get {
                return GetAddedByBusinessName();
            }
        }
        [JsonProperty]
        public string NotificationType {
            get {
                return GetNotificationType();
            }
        }
        [JsonProperty]
        public DateTime NotificationCreatedTime {
            get {
                return GetCreatedTime();
            }
        }


    }
}