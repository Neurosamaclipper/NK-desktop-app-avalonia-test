using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace NeuroKaraokeAvaloniaPlayer.Converters;

public class DurationToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int durationSeconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(durationSeconds);
            return time.ToString(@"mm\:ss");
        }
        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}