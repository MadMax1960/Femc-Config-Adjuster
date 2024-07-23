using System.Globalization;
using System.Windows.Data;

namespace Femc_Config_Adjuster.Helpers;

public class IsNullConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value == null;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value != null;
}
