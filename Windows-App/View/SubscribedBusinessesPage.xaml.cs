﻿using System;
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
using static Windows_App.Model.PageLoadWithMultipleParameters;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubscribedBusinessesPage : Page
    {
        public SubscribedBusinessesPage()
        {
            this.InitializeComponent();
            this.DataContext = new SubsribedBusinessesViewModel();
        }

        private void ListViewBusinesses_ItemClick(object sender, ItemClickEventArgs e)
        {
            Business selectedBusiness = e.ClickedItem as Business;
            PageLoadWithMultipleParameters pageLoad = new PageLoadWithMultipleParameters
            {
                BusinessId = selectedBusiness.Id,
                Pivot = PivotOptions.BUSINESS
            };
            Frame.Navigate(typeof(BusinessDetailPage), pageLoad, new DrillInNavigationTransitionInfo());
        }
    }
}
