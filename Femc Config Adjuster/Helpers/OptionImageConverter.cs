using FemcConfig.Library.Config.Options;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Femc_Config_Adjuster.Helpers;

public class OptionImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var appDir = AppDomain.CurrentDomain.BaseDirectory;
        if (value is ModOption option)
        {
            var imagePath = Path.Join(appDir, "resources", option.InternalName, "image.webp");
            if (File.Exists(imagePath))
            {
                return imagePath;
            }

            return Path.Join(AppDomain.CurrentDomain.BaseDirectory, "resources", "missing.png");
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
