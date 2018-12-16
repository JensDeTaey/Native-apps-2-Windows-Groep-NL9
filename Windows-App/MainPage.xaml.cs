using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows_App.Authentication;
using Windows_App.Data;
using Windows_App.View;

namespace Windows_App
{

    public sealed partial class MainPage : Page, IAuthenticationStatusObserver
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

            //subscribe to the AuthenticationHandler
            AuthenticationHandler.Instance.Attach(this);
            //set default values
            this.Update(AuthenticatedStatusEnum.UNREGISTERED);
        }

        public void Update(AuthenticatedStatusEnum authenticatedStatus)
        {
            //TODO update the available menu buttons
            Debug.WriteLine(authenticatedStatus);
            //resetting all user navigational buttons
            NavMyBusiness.Visibility = Visibility.Collapsed;
            NavRegister.Visibility = Visibility.Collapsed;
            NavLogin.Visibility = Visibility.Collapsed;
            NavLogout.Visibility = Visibility.Collapsed;

            switch (authenticatedStatus)
            {
                case AuthenticatedStatusEnum.UNREGISTERED:
                    NavRegister.Visibility = Visibility.Visible;
                    NavLogin.Visibility = Visibility.Visible;
                    break;
                case AuthenticatedStatusEnum.LOGGEDIN:
                    NavLogout.Visibility = Visibility.Visible;
                    break;
                case AuthenticatedStatusEnum.BUSINESSOWNER:
                    NavMyBusiness.Visibility = Visibility.Visible;
                    NavLogout.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }

            //reset the current frame
            mainFrame.Navigate(typeof(BusinessesPage));
            NavigationContentControlActivated(NavPageBusinessesControl);
        }

        //Collapse of the Navigation
        private void NavCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            PageSplitView.IsPaneOpen = !PageSplitView.IsPaneOpen;
            UserControlsStackpanel.Orientation = PageSplitView.IsPaneOpen ? Orientation.Horizontal : Orientation.Vertical;
        }

        #region Topside navigation

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
        #endregion

        #region User related navigation
        private void NavMyBusiness_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(MyBusinessPage));
            NavigationContentControlActivated(sender);
        }
        private void NavRegister_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(RegisterPage));
            NavigationContentControlActivated(sender);
        }
        private void NavLogin_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(LogInPage));
            NavigationContentControlActivated(sender);
        }
        private void NavLogout_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationHandler.Instance.LogOut();
        }
        #endregion

        #region navigation controls update
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

            if(sender != null)
            {
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
        #endregion
    }
}
