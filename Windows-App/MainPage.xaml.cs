﻿using System;
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
using Windows_App.Navigation;

namespace Windows_App
{

    public sealed partial class MainPage : Page, INavigateablePage
    {
        public SplitView ContainerSplitView => PageSplitView;

        public MainPage()
        {
            this.InitializeComponent();

            NavigationElement.RegisterCurrentPage(this);
        }

    }
}
