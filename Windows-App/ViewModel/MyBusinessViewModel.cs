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
        public MyBusinessViewModel()
        {
            Business = DummyDataSource.BusinessIkea;
            User = DummyDataSource.user1;
            Establishment = DummyDataSource.EstablishmentIkeaGent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void fillRightEstablishment (object tag)
        {
            Establishment = Business.Establishments.Find(esta => esta.Id == (int)tag);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Establishment"));
        }
    }
}
