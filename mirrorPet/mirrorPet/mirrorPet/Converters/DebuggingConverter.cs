using System;
using System.Globalization;
using Xamarin.Forms;

namespace mirrorPet.Converters
{
    public class DebuggingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
