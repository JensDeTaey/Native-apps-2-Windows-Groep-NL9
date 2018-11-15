using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Windows_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationElement : Page
    {

        private static SplitView _containerSplitView;

        public static SplitView ContainerSplitView
        {
            get { return _containerSplitView; }
            set
            {
                if (value == null)
                {
                    throw new Exception("ContainerSplitView mag niet leeg zijn.");
                }
                else
                {
                    _containerSplitView = value;
                }
            }
        }

        public NavigationElement()
        {
            this.InitializeComponent();
        }

        //Collapsing of parent SplitView

        private void NavCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_containerSplitView == null)
            {
                throw new Exception("ContainerSplitView mag niet leeg zijn.");
            }
            _containerSplitView.IsPaneOpen = !_containerSplitView.IsPaneOpen;
        }

        //Navigation

        private void NavPage1StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
