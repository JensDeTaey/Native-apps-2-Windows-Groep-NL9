using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            if (FirstName.Text.Equals("") || LastName.Text.Equals("") || EmailAdress.Text.Equals("") || BusinessName.Text.Equals("") || BusinessDescription.Text.Equals("") || BusinessLink.Text.Equals("") || BusinessPicture.Text.Equals("") || PassWord.Password.Equals("") || RepeatedPassWord.Password.Equals(""))
            {
                RegistreerButton.IsEnabled = false;
            }
        }

        private void Registreer_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
