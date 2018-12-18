using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    class PromotionsViewModel : INotifyPropertyChanged
    {
        private Collection<Promotion> SortedAllPromotions { get; set; }
        private ObservableCollection<Promotion> promotions;

        public ObservableCollection<Promotion> Promotions
        {
            get { return promotions; }
            set
            {
                promotions = value;
                HasNoItems = promotions.Count > 0;
                NotifyPropertyChanged();
            }
        }

        private bool hasNoItems;
        public bool HasNoItems
        {
            get
            {
                return hasNoItems;
            }
            set
            {
                if (hasNoItems != value)
                {
                    hasNoItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PromotionsViewModel()
        {
            SortedAllPromotions = new Collection<Promotion>();
            promotions = new ObservableCollection<Promotion>();
            IDataSource.singleton.FetchPromotions().ContinueWith(t =>
            {
                if (t.Result != null)
                {
                    SortedAllPromotions = t.Result;
                    Promotions = t.Result;
                    SortPromotionsByStartDate(false);
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void SortPromotionsByStartDate(bool ascending)
        {
            //Filter on startDate
            List<Promotion> sortedAllPromotions = SortedAllPromotions.OrderBy(promotion => promotion.StartDate).ToList();
            if (ascending)
                sortedAllPromotions.Reverse();
            SortedAllPromotions = new ObservableCollection<Promotion>(sortedAllPromotions);
            //Sort the filtered list
            List<Promotion> sortedPromotions = Promotions.OrderBy(promotion => promotion.StartDate).ToList();
            if (ascending)
                sortedPromotions.Reverse();
            Promotions = new ObservableCollection<Promotion>(sortedPromotions);
        }

        public void SortPromotionsByEndDate(bool ascending)
        {
            //Filter on startDate
            List<Promotion> sortedAllPromotions = SortedAllPromotions.OrderBy(promotion => promotion.EndDate).ToList();
            if (ascending)
                sortedAllPromotions.Reverse();
            SortedAllPromotions = new ObservableCollection<Promotion>(sortedAllPromotions);
            //Sort the filtered list
            List<Promotion> sortedPromotions = Promotions.OrderBy(promotion => promotion.EndDate).ToList();
            if (ascending)
                sortedPromotions.Reverse();
            Promotions = new ObservableCollection<Promotion>(sortedPromotions);
        }

        internal void FilterOnDiscount(DiscountFilterOption discountFilterOption)
        {
            Promotions = new ObservableCollection<Promotion>(SortedAllPromotions.Where(promotion =>
            {
                switch (discountFilterOption)
                {
                    case DiscountFilterOption.ALL:
                        return true;
                    case DiscountFilterOption.AVAILABLE:
                        return promotion.IsDiscountCoupon;
                    case DiscountFilterOption.NOTAVAILABLE:
                        return !promotion.IsDiscountCoupon;
                    default:
                        return false;
                }
            }
            ));
        }
        public enum DiscountFilterOption
        {
            ALL, AVAILABLE, NOTAVAILABLE
        }

        public void FilterPromotions(string filter)
        {
            //Filter on promotion name and on description
            Promotions = new ObservableCollection<Promotion>(SortedAllPromotions.Where(promotion =>
            promotion.Name.ToLower().Contains(filter.ToLower()) ||
            promotion.Description.ToLower().Contains(filter.ToLower())
            ));
        }

    }
}
