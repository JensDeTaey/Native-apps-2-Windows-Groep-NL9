using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows_App.Navigation;
using Windows_App.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationElement : Page
    {

        private static Page _currentPage;
        private static INavigateablePage _currentNavigateablePage;

        public static void RegisterCurrentPage(Page CurrentPage)
        {
            if (CurrentPage == null)
            {
                throw new Exception("CurrentPage mag niet leeg zijn.");
            }
            else
            {
               if(CurrentPage is INavigateablePage casted)
                {
                    _currentNavigateablePage = casted;
                    _currentPage = CurrentPage;
                }
                else
                {
                    throw new Exception("Pagina is niet navigeerbaar");
                }
            }
        }

        //Shorter code, private variable for the parent frame
        private new Frame Frame => _currentPage.Frame;

        public NavigationElement()
        {
            this.InitializeComponent();
        }

        //Collapsing of parent SplitView

        private void NavCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView containerSplitView = _currentNavigateablePage.ContainerSplitView;
            if (containerSplitView == null)
            {
                throw new Exception("ContainerSplitView mag niet leeg zijn.");
            }
            containerSplitView.IsPaneOpen = !containerSplitView.IsPaneOpen;
        }

        //Navigation

        private void NavPageBusinessesStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BusinessesPage));
            UpdateNavigationItems();
        }

        private void NavPagePromotionsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(PromotionsPage));
            UpdateNavigationItems();
        }

        private void NavPageEventsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(EventsPage));
            UpdateNavigationItems();
        }


        //Enabling en disabming the right navigation item
        private void UpdateNavigationItems()
        {
            Debug.WriteLine("Navs are triggered");
        }

    }
}
