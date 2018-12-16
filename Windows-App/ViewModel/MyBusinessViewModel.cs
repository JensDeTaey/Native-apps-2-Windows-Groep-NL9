using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class MyBusinessViewModel : INotifyPropertyChanged
    {
        public Business Business { get; }
        public User User { get; set; }
       
        public Establishment Establishment { get; set; }
        public Promotion Promotion { get; set; }
        public Event Event { get; set; }
        public MyBusinessViewModel()
        {
            Business = DummyDataSource.BusinessIkea;
            User = DummyDataSource.user1;
            Establishment = DummyDataSource.EstablishmentIkeaGent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void fillRightEstablishment (object tag)
        {
            Establishment = Business.Establishments.FirstOrDefault(esta => esta.Id == (int)tag);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Establishment"));
        }

        public void FillRightPromotion(object tag)
        {
            Promotion = (from sublist in Business.Establishments
                           from item in sublist.Promotions
                           where item.Id == (int)tag
                           select item).FirstOrDefault();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Promotion"));
        }

        public void FillRightEvent(object tag)
        {
            Event = (from sublist in Business.Establishments
                         from item in sublist.Events
                     where item.Id == (int)tag
                         select item).FirstOrDefault();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Event"));
        }

        public void DeleteBusiness()
        {
            throw new NotImplementedException();
        }

        public void DeleteEstablishment()
        {
            throw new NotImplementedException();
        }

        public void DeletePromotion()
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent()
        {
            throw new NotImplementedException();
        }
    }
}
