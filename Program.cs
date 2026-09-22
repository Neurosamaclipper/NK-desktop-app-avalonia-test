using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace NeuroKaraokeAvaloniaPlayer;

internal class Program
{

    public static void Main(string[] args)
    {

        Environment.SetEnvironmentVariable("AVALONIA_DBUS_DISABLE", "1");

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
