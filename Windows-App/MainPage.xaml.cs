using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows_App.View;

namespace Windows_App
{

    public sealed partial class MainPage : Page
    {
        private List<ContentControl> navigationContentControls;

        public MainPage()
        {
            this.InitializeComponent();

            navigationContentControls = new List<ContentControl>()
            {
                NavPageBusinessesContentControl,
                NavPagePromotionsContentControl
            };
        }

        //Collapse of the Navigation
        private void NavCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            PageSplitView.IsPaneOpen = !PageSplitView.IsPaneOpen;
        }

        private void NavigationContentControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!(sender is ContentControl))
                throw new Exception("Can't update tap on NavigationItems, sender is not of type ContentControl");

            //resetting all ContentControls
            foreach (ContentControl navigationItem in navigationContentControls)
            {
                //navigationItem.IsEnabled = true;

                //resetting the content of ContentControl if available
                //Setting the background color on ContentControl does not affect content, so we need to go deeper
                if (navigationItem.Content is StackPanel itemStackPanel)
                {
                    itemStackPanel.Background = default;
                }
            }

            //Casting sender to ContentControl
            ContentControl tappedControl = sender as ContentControl;

            //tappedControl.IsEnabled = false;

            //Setting the color of the content, if available
            if (tappedControl.Content is StackPanel controlStackPanel)
            {
                controlStackPanel.Background = new SolidColorBrush(Color.FromArgb(20, 20, 20, 20));
            }
        }

        #region Navigation Hover

        private void NavigationContentControl_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (!(sender is ContentControl))
                throw new Exception("Can't update hover on NavigationItems, sender is not of type ContentControl");

            ContentControl hoveredControl = sender as ContentControl;

            //Casting content to StackPanel
            //Setting the background color on ContentControl does not affect content, so we need to go deeper
            if (hoveredControl.Content is StackPanel controlStackPanel)
            {
                controlStackPanel.Background = new SolidColorBrush(Color.FromArgb(20, 20, 20, 20));
            }
        }

        private void NavigationContentControl_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (!(sender is ContentControl))
                throw new Exception("Can't update hover on NavigationItems, sender is not of type ContentControl");

            ContentControl hoveredControl = sender as ContentControl;

            //Casting content to StackPanel
            //Setting the background color on ContentControl does not affect content, so we need to go deeper
            if (hoveredControl.Content is StackPanel controlStackPanel)
            {
                controlStackPanel.Background = default;
            }
        }

        #endregion

        private void NavPageBusinessesContentControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(BusinessesPage));
        }

        private void NavPagePromotionsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PromotionsPage));
        }

        private void NavPageEventsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(EventsPage));
        }

    }
}
