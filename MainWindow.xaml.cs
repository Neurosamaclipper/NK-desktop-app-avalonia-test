using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NeuroKaraokeAvaloniaPlayer.ViewModels;

namespace NeuroKaraokeAvaloniaPlayer;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}