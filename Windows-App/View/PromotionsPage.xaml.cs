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
using Windows.UI.Xaml.Navigation;
using Windows_App.Model;

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
            IList<Promotion> list = new List<Promotion>();
            Promotion promotion = new Promotion("Free booze", "Get free booze when you buy booze", new DateTime(2018, 11, 12), new DateTime(2018, 12, 1), false);
            Company comp = new Company();
            comp.Name = "Ikea";
            promotion.Company = comp;
            list.Add(promotion);
            lv.ItemsSource = list;
        }

    }
}
