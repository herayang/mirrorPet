using System;
using System.Globalization;
using Xamarin.Forms;

namespace mirrorPet.Converters
{
    public class UserInputToDouble : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double result = Double.Parse(value.ToString());
                Console.WriteLine(value);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{value.ToString()}'");
                return false;
            }
            
        } 

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
