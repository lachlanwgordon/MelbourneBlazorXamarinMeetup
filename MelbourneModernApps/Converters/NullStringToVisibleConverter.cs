using System;
using System.Globalization;
using Xamarin.Forms;


namespace MelbourneModernApps.Converters
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class NullStringToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string == false)
            {
                return default(bool);
            }

            var input = (string)value;

            // TODO: Put your value conversion logic here.

            return !string.IsNullOrWhiteSpace(input);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}