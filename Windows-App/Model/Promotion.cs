﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
   public class Promotion
    {
        public int BusinessId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        private string picture;
        public string Picture
        {
            //return default value if Picture is not set
            get { return (picture is null || picture =="")? "../Images/promotion.png" : picture; }
            set { picture = value; }
        }
        public bool IsDiscountCoupon { get; set; }
        public int EstablishmentId { get; set; }

        public string TimeValid
        {
            get
            {
                return String.Format("{0} - {1}", StartDate.ToString("dd/MM/yyyy"), EndDate.ToString("dd/MM/yyyy"));
            }
        }
        public string NeedCoupon
        {
            get
            {
                return String.Format("{0}", IsDiscountCoupon ? "Ja" : "Nee");
            }
        }
    }


}
