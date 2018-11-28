using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
    class Promotion
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long Picture { get; set; }
        public bool IsDiscountCoupon { get; set; }

        public Company Company { get; set; }

        public string TimeValid {
            get {
                return String.Format("{0} - {1}", StartDate.ToString("MM/dd/yyyy"), EndDate.ToString("MM/dd/yyyy"));
            }
        }
        public string NeedCoupon {
            get {
                return String.Format("{0}", IsDiscountCoupon?"Yes":"No");
            }
        }


        public Promotion(string name, string description, DateTime startDate, DateTime endDate, bool isDiscountCoupon)
        {
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.IsDiscountCoupon = isDiscountCoupon;

        }
    }
}
