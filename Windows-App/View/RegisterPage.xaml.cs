using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        ObservableCollection<string> Categories = new ObservableCollection<string>();
        public RegisterPage()
        {
            this.InitializeComponent();
            Categories.Add("Interieur");
            Categories.Add("Kledingzaak");
            Categories.Add("Eten");
            Categories.Add("Meubels");
            Categories.Add("Supermarkt");
            Categories.Add("Alleszaak");

            CheckRequirements();
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
                Category = CategoriesCombo.SelectedValue == null?"": CategoriesCombo.SelectedValue.ToString(),
                LinkWebsite = BusinessLink.Text,
                Picture = BusinessPicture.Text
            };

            IDataSource.singleton.Register(model).ContinueWith(async t =>
            {
                if (t.Result)
                {
                    await ShowNotificationAsync("Gebruiker aangemaakt, je kan je nu inloggen!", true);
                }
                else
                {
                    await ShowNotificationAsync("Er ging iets fout bij het registreren!", false);
                    
                }
            });
        }


        private void UserSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (!UserSwitch.IsOn)
            {
                BusinessName.Visibility = Visibility.Collapsed;
                BusinessDescription.Visibility = Visibility.Collapsed;
                CategoriesCombo.Visibility = Visibility.Collapsed;
                BusinessLink.Visibility = Visibility.Collapsed;
                BusinessPicture.Visibility = Visibility.Collapsed;
            }
            else if(BusinessName != null)
            {
                BusinessName.Visibility = Visibility.Visible;
                BusinessDescription.Visibility = Visibility.Visible;
                CategoriesCombo.Visibility = Visibility.Visible;
                BusinessLink.Visibility = Visibility.Visible;
                BusinessPicture.Visibility = Visibility.Visible;
            }
        }
        public void CheckRequirements()
        {
            if (FirstName.Text.Equals("")
                || LastName.Text.Equals("")
                || EmailAdress.Text.Equals("")
                || PassWord.Password.Equals("")
                || RepeatedPassWord.Password.Equals("")
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

        private async System.Threading.Tasks.Task ShowNotificationAsync(string text, bool hasRedirectAction) => await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            async () =>
            {
                MessageDialog dialog = new MessageDialog(text);
                dialog.Commands.Add(new UICommand("Sluit", null));
                dialog.Commands.Add(new UICommand("Naar inlogscherm", null));
                dialog.DefaultCommandIndex = 1;

                var cmd = await dialog.ShowAsync();

                if (cmd.Label == "Naar inlogscherm")
                {
                    // do something
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
