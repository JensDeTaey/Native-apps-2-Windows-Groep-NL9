using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows_App.Data;
using Windows_App.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        
        public RegisterPage()
        {
          
            CheckRequirements();
            UserSwitch_Toggled(null, null);
        }

        private void Registreer_Click(object sender, RoutedEventArgs e)
        {
            RegisterViewModel model = new RegisterViewModel()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = EmailAdress.Text,
                Password = PassWord.Password,
                ConfirmPassword = RepeatedPassWord.Password,
                IsBusinessAccount = UserSwitch.IsOn,
                BusinessName = BusinessName.Text,
                Description = BusinessDescription.Text,
                Category = BusinessCategorie.Text,
                LinkWebsite = BusinessLink.Text,
                Picture = BusinessPicture.Text
            };

            DisableInput(false);

            IDataSource.singleton.Register(model).ContinueWith(async t =>
            {
                if (t.Result)
                {
                    
                    await ShowNotificationAsync("Gebruiker aangemaakt, je kan je nu inloggen!", true);
                }
                else
                {
                    DisableInput(true);
                    await ShowNotificationAsync("Er ging iets fout bij het registreren!", false);
                    
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void DisableInput(bool v)
        {
            FirstName.IsEnabled = v;
            LastName.IsEnabled = v;
            EmailAdress.IsEnabled = v;
            PassWord.IsEnabled = v;
            RepeatedPassWord.IsEnabled = v;
            UserSwitch.IsEnabled = v;
            BusinessName.IsEnabled = v;
            BusinessDescription.IsEnabled = v;
            BusinessCategorie.IsEnabled = v;
            BusinessLink.IsEnabled = v;
            BusinessPicture.IsEnabled = v;

            RegistreerButton.IsEnabled = v;
            
        }

        private void UserSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (!UserSwitch.IsOn)
            {
                BusinessName.Visibility = Visibility.Collapsed;
                BusinessDescription.Visibility = Visibility.Collapsed;
                BusinessCategorie.Visibility = Visibility.Collapsed;
                BusinessLink.Visibility = Visibility.Collapsed;
                BusinessPicture.Visibility = Visibility.Collapsed;
            }
            else if(BusinessName != null)
            {
                BusinessName.Visibility = Visibility.Visible;
                BusinessDescription.Visibility = Visibility.Visible;
                BusinessCategorie.Visibility = Visibility.Visible;
                BusinessLink.Visibility = Visibility.Visible;
                BusinessPicture.Visibility = Visibility.Visible;
            }
            CheckRequirements();
        }
        public void CheckRequirements()
        {
            if (FirstName.Text.Equals("")
                || LastName.Text.Equals("")
                || EmailAdress.Text.Equals("")
                || PassWord.Password.Equals("")
                || !IsValidEmail(EmailAdress.Text)
                || RepeatedPassWord.Password.Equals("")
                || !PassWord.Password.Equals(RepeatedPassWord.Password)
                || PassWord.Password.Length <6
                || (UserSwitch.IsOn && (
                    BusinessName.Text.Equals("")
                    || BusinessDescription.Text.Equals("")
                    || BusinessLink.Text.Equals("")
                    || BusinessPicture.Text.Equals(""))
                    )
                )
            {
                RegistreerButton.IsEnabled = false;
            }
            else
            {
                RegistreerButton.IsEnabled = true;
            }
        }

        bool IsValidEmail(string email)
        {

            return new EmailAddressAttribute().IsValid(email);

        }

        private async System.Threading.Tasks.Task ShowNotificationAsync(string text, bool hasRedirectAction) => await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            async () =>
            {
                MessageDialog dialog = new MessageDialog(text);
                if (hasRedirectAction)
                {
                    dialog.Commands.Add(new UICommand("Naar inlogscherm", null));
                } else
                {
                    dialog.Commands.Add(new UICommand("Sluit", null));
                }
                
                
                dialog.DefaultCommandIndex = 1;

                var cmd = await dialog.ShowAsync();
                
                if (cmd.Label == "Naar inlogscherm")
                {
                    Frame.Navigate(typeof(LogInPage));
                } else
                {
                    DisableInput(true);
                }
            });

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckRequirements();
        }

        private void SwitchChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CheckRequirements();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckRequirements();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckRequirements();
        }
    }
}
