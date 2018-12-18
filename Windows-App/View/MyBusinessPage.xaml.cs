﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
                    myBusinessViewModel.TriggerBusinessUpdate();
                    SetBusinessFieldsEnabled(!BusinessName.IsEnabled);
                    break;
                case 1:
                    myBusinessViewModel.TriggerEstablishmentUpdate();
                    SetEstablishmentFieldsEnabled(!EstablishmentName.IsEnabled);
                    break;
                case 2:
                    myBusinessViewModel.TriggerPromotionUpdate();
                    SetPromotionFieldsEnabled(!PromotionName.IsEnabled);
                    break;
                case 3:
                    myBusinessViewModel.TriggerEventUpdate();
                    SetEventFieldsEnabled(!EventName.IsEnabled);
                    break;
            }
        }

        private void SetEventFieldsEnabled(bool isEnabled)
        {
            EventName.IsEnabled = isEnabled;
            EventDescription.IsEnabled = isEnabled;
            EventPicture.IsEnabled = isEnabled;
            StartDateEventCalendarDatePicker.IsEnabled = isEnabled;
            EndDateEventCalendarDatePicker.IsEnabled = isEnabled;
        }

        private void SetPromotionFieldsEnabled(bool isEnabled)
        {
            PromotionName.IsEnabled = isEnabled;
            PromotionDescription.IsEnabled = isEnabled;
            PromotionPicture.IsEnabled = isEnabled;
            StartDatePromotionCalendarDatePicker.IsEnabled = isEnabled;
            EndDatePromotionCalendarDatePicker.IsEnabled = isEnabled;
            CouponSwitch.IsEnabled = isEnabled;
        }
        

        private void SetEstablishmentFieldsEnabled(bool isEnabled)
        {
            EstablishmentName.IsEnabled = isEnabled;
            EstablishmentAddress.IsEnabled = isEnabled;
            EstablishmentPhoneNumber.IsEnabled = isEnabled;
            EstablishmentEmail.IsEnabled = isEnabled;
            EstablishmentPicture.IsEnabled = isEnabled;
            EstablishmentMondayOpeningsHour.IsEnabled = IsEnabled;
            EstablishmentMondayClosingsHour.IsEnabled = IsEnabled;
            EstablishmentTuesdayOpeningsHour.IsEnabled = IsEnabled;
            EstablishmentTuesdayClosingsHour.IsEnabled = IsEnabled;
            EstablishmentWednesdayOpeningsHour.IsEnabled = IsEnabled;
            EstablishmentWednesdayClosingsHour.IsEnabled = IsEnabled;
            EstablishmentThursdayOpeningsHour.IsEnabled = IsEnabled;
            EstablishmentThursdayClosingsHour.IsEnabled = IsEnabled;
            EstablishmentFridayOpeningsHour.IsEnabled = IsEnabled;
            EstablishmentFridayClosingsHour.IsEnabled = IsEnabled;
            EstablishmentSaturdayOpeningsHour.IsEnabled = IsEnabled;
            EstablishmentSaturdayClosingsHour.IsEnabled = IsEnabled;
            EstablishmentSundayOpeningsHour.IsEnabled = IsEnabled;
            EstablishmentSundayClosingsHour.IsEnabled = IsEnabled;
            EstablishmentMondayIsClosed.IsEnabled = IsEnabled;
            EstablishmentTuesdayIsClosed.IsEnabled = IsEnabled;
            EstablishmentWednesdayIsClosed.IsEnabled = IsEnabled;
            EstablishmentThursdayIsClosed.IsEnabled = IsEnabled;
            EstablishmentFridayIsClosed.IsEnabled = IsEnabled;
            EstablishmentSaturdayIsClosed.IsEnabled = IsEnabled;
            EstablishmentSundayIsClosed.IsEnabled = IsEnabled;
            //OpeningsHoursListView.IsEnabled = isEnabled;
        }

       

        private void SetBusinessFieldsEnabled(bool isEnabled)
        {
            BusinessName.IsEnabled = isEnabled;
            BusinessDescription.IsEnabled = isEnabled;
            BusinessLink.IsEnabled = isEnabled;
            BusinessPicture.IsEnabled = isEnabled;
            CategoriesCombo.IsEnabled = isEnabled;
        }

        private void AppBarSave_click(object sender, RoutedEventArgs e)
        {
            int index = PivotMyBusiness.SelectedIndex;
            switch (index)
            {
                case 0:
                    //We are editing the business itself
                    Business business = new Business()
                    {
                        Name = BusinessName.Text,
                        Description = BusinessDescription.Text,
                        Picture = BusinessPicture.Text,
                        Category = "haha yes", //Todo
                        LinkWebsite = BusinessLink.Text,

                    };

                    myBusinessViewModel.SaveBusiness(business).ContinueWith(async t => {
                        if(t.Result)
                        {
                            SetBusinessFieldsEnabled(false);
                            //Request was succes
                        } else
                        {
                            await ShowNotificationAsync("Er ging iets fout bij het bewerken, heb je alle velden ingevuld?");
                            //Request failed
                        }
                        
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case 1:
                    //We are editing an establishment
                    List<OpeningHour> hours = new List<OpeningHour>();
                    //var source = OpeningsHoursListView.ItemsSource as List<OpeningHour>;
                    OpeningHour maandag = new OpeningHour() {
                        Day = DaysOfWeek.DaysOfWeekEnum.Monday,
                        OpeningsHour = EstablishmentMondayOpeningsHour.SelectedTime.Value.ToString("HH:mm"),
                        ClosingsHour = EstablishmentMondayClosingsHour.SelectedTime.Value.ToString("HH:mm"),
                        IsClosed = EstablishmentMondayIsClosed.IsChecked.Value
                    };
                    OpeningHour dinsdag = new OpeningHour()
                    {
                        Day = DaysOfWeek.DaysOfWeekEnum.Tuesday,
                        OpeningsHour = EstablishmentTuesdayOpeningsHour.SelectedTime.Value.ToString("HH:mm"),
                        ClosingsHour = EstablishmentTuesdayClosingsHour.SelectedTime.Value.ToString("HH:mm"),
                        IsClosed = EstablishmentTuesdayIsClosed.IsChecked.Value
                    };
                    OpeningHour woensdag = new OpeningHour()
                    {
                        Day = DaysOfWeek.DaysOfWeekEnum.Wednesday,
                        OpeningsHour = EstablishmentWednesdayOpeningsHour.SelectedTime.Value.ToString("HH:mm"),
                        ClosingsHour = EstablishmentWednesdayClosingsHour.SelectedTime.Value.ToString("HH:mm"),
                        IsClosed = EstablishmentWednesdayIsClosed.IsChecked.Value
                    };
                    OpeningHour donderdag = new OpeningHour()
                    {
                        Day = DaysOfWeek.DaysOfWeekEnum.Thursday,
                        OpeningsHour = EstablishmentThursdayOpeningsHour.SelectedTime.Value.ToString("HH:mm"),
                        ClosingsHour = EstablishmentThursdayClosingsHour.SelectedTime.Value.ToString("HH:mm"),
                        IsClosed = EstablishmentThursdayIsClosed.IsChecked.Value
                    };
                    OpeningHour vrijdag = new OpeningHour()
                    {
                        Day = DaysOfWeek.DaysOfWeekEnum.Friday,
                        OpeningsHour = EstablishmentFridayOpeningsHour.SelectedTime.Value.ToString("HH:mm"),
                        ClosingsHour = EstablishmentFridayClosingsHour.SelectedTime.Value.ToString("HH:mm"),
                        IsClosed = EstablishmentFridayIsClosed.IsChecked.Value
                    };
                    OpeningHour zaterdag = new OpeningHour()
                    {
                        Day = DaysOfWeek.DaysOfWeekEnum.Saturday,
                        OpeningsHour = EstablishmentSaturdayOpeningsHour.SelectedTime.Value.ToString("HH:mm"),
                        ClosingsHour = EstablishmentSaturdayClosingsHour.SelectedTime.Value.ToString("HH:mm"),
                        IsClosed = EstablishmentSaturdayIsClosed.IsChecked.Value
                    };
                    OpeningHour zondag = new OpeningHour()
                    {
                        Day = DaysOfWeek.DaysOfWeekEnum.Sunday,
                        OpeningsHour = EstablishmentSundayOpeningsHour.SelectedTime.Value.ToString("HH:mm"),
                        ClosingsHour = EstablishmentSundayClosingsHour.SelectedTime.Value.ToString("HH:mm"),
                        IsClosed = EstablishmentSundayIsClosed.IsChecked.Value
                    };
                    hours.Add(maandag);
                    hours.Add(dinsdag);
                    hours.Add(woensdag);
                    hours.Add(donderdag);
                    hours.Add(vrijdag);
                    hours.Add(zaterdag);
                    hours.Add(zondag);
                    Establishment establishment = new Establishment()
                    {
                        Name = EstablishmentName.Text,
                        Address = EstablishmentAddress.Text,
                        PhoneNumber = EstablishmentPhoneNumber.Text,
                        Email = EstablishmentEmail.Text,
                        Picture = EstablishmentPicture.Text,
                        AllOpeningHours = hours.Where(hour => !hour.IsClosed).ToList<OpeningHour>()
                    };

                    myBusinessViewModel.SaveEstablishment(establishment).ContinueWith(t=>
                    {
                        if (t.Result)
                        {
                            //Request was succes
                            SetEstablishmentFieldsEnabled(false);
                        }
                        else
                        {
                            //Request failed
                        }

                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case 2:
                    
                    //We are editing a promotion
                    Promotion promotion = new Promotion()
                    {
                        Name = PromotionName.Text,
                        Description = PromotionDescription.Text,
                        Picture = PromotionPicture.Text,
                        StartDate = StartDatePromotionCalendarDatePicker.Date.Value,
                        EndDate = EndDateEventCalendarDatePicker.Date.Value,
                        IsDiscountCoupon = CouponSwitch.IsOn
                    };
                    //adding a new promotion
                    if (myBusinessViewModel.Promotion == null)
                    {
                        myBusinessViewModel.AddPromotion(promotion).ContinueWith(t => {
                            if (t.Result)
                            {
                                //Request was succes
                                SetPromotionFieldsEnabled(false);
                            }
                            else
                            {
                                //Request failed
                            }
                        }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else
                    {
                        myBusinessViewModel.SavePromotion(promotion).ContinueWith(t => {
                            if (t.Result)
                            {
                                //Request was succes
                                SetPromotionFieldsEnabled(false);
                            }
                            else
                            {
                                //Request failed
                            }
                        }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                    }


                    
                    break;
                case 3:
                    //We are editing an event
                    Event @event = new Event()
                    {
                        Name = EventName.Text,
                        Description = EventDescription.Text,
                        Picture = EventPicture.Text,
                        StartDate = StartDateEventCalendarDatePicker.Date.Value,
                        EndDate = EndDateEventCalendarDatePicker.Date.Value,
                    };

                    //adding a new event
                    if (myBusinessViewModel.Event == null)
                    {
                        myBusinessViewModel.AddEvent(@event).ContinueWith(t => {
                            if (t.Result)
                            {
                                //Request was succes
                                SetPromotionFieldsEnabled(false);
                            }
                            else
                            {
                                //Request failed

                            }
                        }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else
                    {
                        //edit an event
                        myBusinessViewModel.SaveEvent(@event).ContinueWith(t => {
                            if (t.Result)
                            {
                                //Request was succes
                                SetEventFieldsEnabled(false);
                            }
                            else
                            {
                                //Request failed
                            }
                        }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    
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
                    SetEstablishmentFieldsEnabled(true);
                    

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
                    //They can't do this >:(
                    break;
                //delete an establishment
                case 1:
                    myBusinessViewModel.DeleteEstablishment().ContinueWith(t => {
                        if (t.Result)
                        {
                            //Request was succes

                        }
                        else
                        {
                            //Request failed
                        }
                    });
                    break;
                //delete a promotion
                case 2:
                    myBusinessViewModel.DeletePromotion().ContinueWith(t => {
                        if (t.Result)
                        {
                            //Request was succes
                        }
                        else
                        {
                            //Request failed
                        }
                    });
                    break;
                //delete an event
                case 3:
                    myBusinessViewModel.DeleteEvent().ContinueWith(t => {
                        if (t.Result)
                        {
                            //Request was succes
                        }
                        else
                        {
                            //Request failed
                        }
                    });
                    break;
            }
        }

        private void PromotionAdd_Click(object sender, RoutedEventArgs e)
        {
            SetPromotionFieldsEnabled(true);
            myBusinessViewModel.Promotion = null;
            myBusinessViewModel.TriggerPromotionUpdate();
            myBusinessViewModel.fillRightEstablishment(((Button)sender).Tag);
        }

        private void EventAdd_Click(object sender, RoutedEventArgs e)
        {
            SetEventFieldsEnabled(true);
            myBusinessViewModel.Event = null;
            myBusinessViewModel.TriggerEventUpdate();
            myBusinessViewModel.fillRightEstablishment(((Button)sender).Tag);
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


        private async System.Threading.Tasks.Task ShowNotificationAsync(string text) => await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            async () =>
            {
                MessageDialog dialog = new MessageDialog(text);
                dialog.Commands.Add(new UICommand("Sluit", null));
                dialog.DefaultCommandIndex = 1;
                var cmd = await dialog.ShowAsync();

                if (cmd.Label == "Sluit")
                {
                    // do something
                }
            });
    }
}
