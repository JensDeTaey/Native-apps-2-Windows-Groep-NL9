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
using Windows_App.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyBusinessPage : Page
    {
        private MyBusinessViewModel myBusinessViewModel;
        public MyBusinessPage()
        {
            this.InitializeComponent();
            myBusinessViewModel = new MyBusinessViewModel();
            this.DataContext = myBusinessViewModel;


            if (PivotMyBusiness.SelectedIndex == 0)
            {
                AddButton.IsEnabled = false;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PivotMyBusiness.SelectedIndex == 0)
            {
                FirstName.IsEnabled = !FirstName.IsEnabled;
                LastName.IsEnabled = !LastName.IsEnabled;
                EmailAdress.IsEnabled = !EmailAdress.IsEnabled;
                BusinessName.IsEnabled = !BusinessName.IsEnabled;
                BusinessDescription.IsEnabled = !BusinessDescription.IsEnabled;
                BusinessLink.IsEnabled = !BusinessLink.IsEnabled;
                BusinessPicture.IsEnabled = !BusinessPicture.IsEnabled;
                CategoriesCombo.IsEnabled = !CategoriesCombo.IsEnabled;
                
            }
        }

        private void Establishment_click(object sender, RoutedEventArgs e)
        {
           myBusinessViewModel.fillRightEstablishment(((Button)sender).Tag);
        }
    }
}
