using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows_App.Model;
using Windows_App.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PromotionsPage : Page
    {
        public PromotionsPage()
        {
            this.InitializeComponent();
            this.DataContext = new PromotionsViewModel();
        }

        private void ListViewPromotions_ItemClick(object sender, ItemClickEventArgs e)
        {
          Promotion selectedPromotion = e.ClickedItem as Promotion;
          Frame.Navigate(typeof(BusinessDetailPage), new BusinessDetailViewModel(selectedPromotion), new DrillInNavigationTransitionInfo());
            
        }
    }
}
