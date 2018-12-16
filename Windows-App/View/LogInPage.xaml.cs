using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows_App.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogInPage : Page
    {
        public LogInPage()
        {
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = false;

           string emailAddress = EmailAdress.Text.Trim();
            string passWord = Password.Password.ToString().Trim();

            AuthenticationHandler.Instance.LogIn(emailAddress, passWord).ContinueWith(t =>
            {
                LoginButton.IsEnabled = true;

                if (t.Result)
                {
                    //login succeeded
                    LoginErrorLabel.Visibility = Visibility.Collapsed;
                    AuthenticationHandler.Instance.ContinueAfterLogin();
                }
                else
                {
                    //login failed
                    LoginErrorLabel.Visibility = Visibility.Visible;
                };

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            
        }
    }
}
