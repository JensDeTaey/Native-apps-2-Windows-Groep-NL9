using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Windows_App.View
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value,
            Type targetType, object parameter, string language)
        {
            bool isHidden = (bool)value;
            return isHidden ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
