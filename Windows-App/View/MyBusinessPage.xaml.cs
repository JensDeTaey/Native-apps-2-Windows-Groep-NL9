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
using Windows_App.Model;
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


            
        }

        private void AppBarEdit_Click(object sender, RoutedEventArgs e)
        {
            int index = PivotMyBusiness.SelectedIndex;
            switch (index)
            {
                case 0:
                    FirstName.IsEnabled = !FirstName.IsEnabled;
                    LastName.IsEnabled = !LastName.IsEnabled;
                    EmailAdress.IsEnabled = !EmailAdress.IsEnabled;
                    BusinessName.IsEnabled = !BusinessName.IsEnabled;
                    BusinessDescription.IsEnabled = !BusinessDescription.IsEnabled;
                    BusinessLink.IsEnabled = !BusinessLink.IsEnabled;
                    BusinessPicture.IsEnabled = !BusinessPicture.IsEnabled;
                    CategoriesCombo.IsEnabled = !CategoriesCombo.IsEnabled;
                    break;
                case 1:
                    EstablishmentName.IsEnabled = !EstablishmentName.IsEnabled;
                    EstablishmentAddress.IsEnabled = !EstablishmentAddress.IsEnabled;
                    EstablishmentPhoneNumber.IsEnabled = !EstablishmentPhoneNumber.IsEnabled;
                    EstablishmentEmail.IsEnabled = !EstablishmentEmail.IsEnabled;
                    EstablishmentPicture.IsEnabled = !EstablishmentPicture.IsEnabled;
                    OpeningsHoursListView.IsEnabled = !OpeningsHoursListView.IsEnabled;
                    break;
                case 2:
                    PromotionName.IsEnabled = !PromotionName.IsEnabled;
                    PromotionDescription.IsEnabled = !PromotionDescription.IsEnabled;
                    PromotionPicture.IsEnabled = !PromotionPicture.IsEnabled;
                    StartDatePromotionCalendarDatePicker.IsEnabled = !StartDatePromotionCalendarDatePicker.IsEnabled;
                    EndDatePromotionCalendarDatePicker.IsEnabled = !EndDatePromotionCalendarDatePicker.IsEnabled;
                    CouponSwitch.IsEnabled = !CouponSwitch.IsEnabled;
                    break;
                case 3:
                    EventName.IsEnabled = !EventName.IsEnabled;
                    EventDescription.IsEnabled = !EventDescription.IsEnabled;
                    EventPicture.IsEnabled = !EventPicture.IsEnabled;
                    StartDateEventCalendarDatePicker.IsEnabled = !StartDateEventCalendarDatePicker.IsEnabled;
                    EndDateEventCalendarDatePicker.IsEnabled = !EndDateEventCalendarDatePicker.IsEnabled;
                    break;
            }
        }

        private void AppBarSave_click(object sender, RoutedEventArgs e)
        {
            int index = PivotMyBusiness.SelectedIndex;
            switch (index)
            {
                case 0:
                    Business business = new Business()
                    {
                        Name = BusinessName.Text,
                        Description = BusinessDescription.Text,
                        Picture = BusinessPicture.Text,
                        Category = "haha yes", //Todo
                        LinkWebsite = BusinessLink.Text,

                    };
                    myBusinessViewModel.SaveBusiness(business);
                    break;
                case 1:
                    Establishment establishment = new Establishment()
                    {
                        Name = EstablishmentName.Text,
                        Address = EstablishmentAddress.Text,
                        PhoneNumber = EstablishmentPhoneNumber.Text,
                        Email = EstablishmentEmail.Text,
                        Picture = EstablishmentPicture.Text,
                        OpeningHours = new List<OpeningHour>()
                        //TODO: opening hours
                    };
                    myBusinessViewModel.SaveEstablishment(establishment);
                    break;
                case 2:
                    Promotion promotion = new Promotion()
                    {
                        Name = PromotionName.Text,
                        Description = PromotionDescription.Text,
                        Picture = PromotionPicture.Text,
                        StartDate = StartDatePromotionCalendarDatePicker.Date.Value,
                        EndDate = EndDateEventCalendarDatePicker.Date.Value,
                        IsDiscountCoupon = CouponSwitch.IsEnabled
                    };
                    myBusinessViewModel.SavePromotion(promotion);
                    break;
                case 3:
                    Event @event = new Event()
                    {
                        Name = PromotionName.Text,
                        Description = PromotionDescription.Text,
                        Picture = PromotionPicture.Text,
                        StartDate = StartDatePromotionCalendarDatePicker.Date.Value,
                        EndDate = EndDateEventCalendarDatePicker.Date.Value,
                    };
                    myBusinessViewModel.SaveEvent(@event);
                    break;
            }
        }

        private void Establishment_click(object sender, RoutedEventArgs e)
        {
           myBusinessViewModel.fillRightEstablishment(((Button)sender).Tag);
        }

        private void Promotion_click(object sender, RoutedEventArgs e)
        {
            myBusinessViewModel.FillRightPromotion(((Button)sender).Tag);
        }

        private void Event_click(object sender, RoutedEventArgs e)
        {
            myBusinessViewModel.FillRightEvent(((Button)sender).Tag);
        }

        private void AppBarAdd_Click(object sender, RoutedEventArgs e)
        {
            int index = PivotMyBusiness.SelectedIndex;
            switch (index)
            {
                
                //add an establishment
                case 1:
                    //EstablishmentName.IsEnabled = true;
                    //EstablishmentAddress.IsEnabled = true;
                    //EstablishmentPhoneNumber.IsEnabled = true;
                    //EstablishmentEmail.IsEnabled = true;
                    //EstablishmentPicture.IsEnabled = true;
                    //OpeningsHoursListView.IsEnabled = true;
                    //EstablishmentName.Text = "";
                    //EstablishmentAddress.Text = "";
                    //EstablishmentPhoneNumber.Text = "";
                    //EstablishmentEmail.Text = "";
                    //EstablishmentPicture.Text = "";
                    //OpeningsHoursListView.DataContext = null;
                    break;
                //add a promotion
                case 2:
                    
                    break;
                //add an event
                case 3:
                    
                    break;
            }
        }
        
        private void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            int index = PivotMyBusiness.SelectedIndex;
            switch (index)
            {
                //delete an business
                case 0:
                    myBusinessViewModel.DeleteBusiness();
                    break;
                //delete an establishment
                case 1:
                    myBusinessViewModel.DeleteEstablishment();
                    break;
                //delete a promotion
                case 2:
                    myBusinessViewModel.DeletePromotion();
                    break;
                //delete an event
                case 3:
                    myBusinessViewModel.DeleteEvent();
                    break;
            }
        }

        private void PivotMyBusiness_PivotItemLoading(Pivot sender, PivotItemEventArgs args)
        {
            if (PivotMyBusiness.SelectedIndex == 0)
            {
                AddButton.IsEnabled = false;
            }
            else
            {
                AddButton.IsEnabled = true;
            }
        }
    }
}
