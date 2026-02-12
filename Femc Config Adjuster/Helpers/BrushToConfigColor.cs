using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using FemcConfig.Library.Config.Models;

namespace Femc_Config_Adjuster.Helpers;

internal class BrushToConfigColor : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ConfigColor color)
        {
            return new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
        }
        return new SolidColorBrush(Color.FromArgb(byte.MaxValue, 0, 0, 0));
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brush)
        {
            var color = brush.Color;
            return new ConfigColor(color.R, color.G, color.B, color.A);
        }

        return new ConfigColor(0, 0, 0, byte.MaxValue);
    }
}