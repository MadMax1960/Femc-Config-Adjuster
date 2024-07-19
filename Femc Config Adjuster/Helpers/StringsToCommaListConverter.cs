using System.Globalization;
using System.Windows.Data;

namespace Femc_Config_Adjuster.Helpers;

public class StringsToCommaListConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is IEnumerable<string> strings)
        {
            return string.Join(", ", strings);
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
