using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NeuroKaraokeAvaloniaPlayer.ViewModels;

namespace NeuroKaraokeAvaloniaPlayer.Views;

public partial class RadioView : UserControl
{
    public RadioView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void OnRefreshClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is ViewModels.RadioViewModel vm)
        {
            await vm.Refresh();
        }
    }
}