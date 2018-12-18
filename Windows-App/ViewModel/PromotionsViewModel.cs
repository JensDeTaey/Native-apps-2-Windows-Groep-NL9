using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    class PromotionsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Promotion> Promotions { get; set; }
        public PromotionsViewModel()
        {
            
        }

        public Task LoadData()
        {
            return IDataSource.singleton.FetchPromotions().ContinueWith(t =>
            {
                this.Promotions = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Promotions"));
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Promotion getPromotion(object tag)
        {
            return Promotions.FirstOrDefault(promotion => promotion.Id == (int)tag);
        }
    }
}
