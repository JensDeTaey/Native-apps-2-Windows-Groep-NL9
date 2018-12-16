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
        private List<Control> navigationButtonControls;

        public MainPage()
        {
            this.InitializeComponent();

            navigationButtonControls = new List<Control>()
            {
                 NavPageBusinessesControl,
                 NavPagePromotionsControl,
                 NavPageEventsContentControl,
                 NavRegister,
                 NavMyBusiness,
                 NavRegister,
                 NavLogin,
                 NavLogout
            };
        }

        //Collapse of the Navigation
        private void NavCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            PageSplitView.IsPaneOpen = !PageSplitView.IsPaneOpen;
            UserControlsStackpanel.Orientation = PageSplitView.IsPaneOpen ? Orientation.Horizontal : Orientation.Vertical;
        }

        private void NavPageBusinessesControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(BusinessesPage));
            NavigationContentControlActivated(sender);
        }

        private void NavPagePromotionsControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PromotionsPage));
            NavigationContentControlActivated(sender);
        }

        private void NavPageEventsContentControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(EventsPage));
            NavigationContentControlActivated(sender);
        }

        private void NavPageRegisterContentControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(RegisterPage));
            NavigationContentControlActivated(sender);
        }
        private void NavPageLoginContentControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(LogInPage));
            NavigationContentControlActivated(sender);
        }
        private void NavPageMyBusiness_click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(MyBusinessPage));
            NavigationContentControlActivated(sender);
        }
        private void NavigationContentControlActivated(object sender)
        {
            //resetting all navigation Controls
            Style navigationButtonStyle = this.Resources["NavigationButtonStyle"] as Style;
            Style navigationAppBarButtonStyle = this.Resources["NavigationAppBarButtonStyle"] as Style;

            foreach (ContentControl navigationItem in navigationButtonControls)
            {
                //check what type the button is
                if (!(navigationItem is AppBarButton))
                {
                    navigationItem.Style = navigationButtonStyle;
                }
                else
                {
                    navigationItem.Style = navigationAppBarButtonStyle;
                }
            }

            //set style of selected button
            Control tappedControl = sender as Control;
            if (!(tappedControl is AppBarButton))
            {
                tappedControl.Style = (Style)this.Resources["SelectedNavigationButtonStyle"];
            }
            else
            {
                tappedControl.Style = (Style)this.Resources["SelectedNavigationAppBarButtonStyle"];
            }
        }
    }
}
