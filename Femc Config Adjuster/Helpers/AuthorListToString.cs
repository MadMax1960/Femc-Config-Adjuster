using FemcConfig.Library.Config.Options;
using System.Globalization;
using System.Windows.Data;

namespace Femc_Config_Adjuster.Helpers;

public class AuthorListToString : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is IEnumerable<Author> authors)
        {
            return string.Join(", ", authors.Select(x => x.Name));
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value;
}
