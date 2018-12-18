using BackendV7.Models.Domein;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendV7
{
    public class Promotion : Notification
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonProperty("Picture")]
        public string PictureURL { get; set; }
        public bool IsDiscountCoupon { get; set; }

        public DateTime Created { get; set; }

        public int BusinessId {
            get {
                return Establishment== null?-1:Establishment.BusinessId;
            }
        }

        //Assocations
        public int EstablishmentId { get; set; }
        [JsonIgnore]
        public Establishment Establishment { get; set; }

        //Notification
        public override string GetAddedByBusinessName()
        {
            return Establishment == null ? "" : Establishment.Business == null ? "" : Establishment.Business.Name;
        }

        public override int GetBusinessId()
        {
            return Establishment == null ? -1 : Establishment.Business == null ? -1 : Establishment.Business.Id;
        }

        public override DateTime GetCreatedTime()
        {
            return Created;
        }

        public override string GetDescription()
        {
            return Description;
        }

        public override int GetEstablishmentId()
        {
            return Establishment == null ? -1 : Establishment.Id;
        }

        public override string GetNotificationType()
        {
            return "PROMOTION";
        }

        public override string GetTitle()
        {
            return Name;
        }

        public override string GetEstablishmentName()
        {
            return Establishment == null ? "" : Establishment.Name;
        }


    }


}
