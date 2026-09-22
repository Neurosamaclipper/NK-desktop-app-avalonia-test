using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NeuroKaraokeAvaloniaPlayer.ViewModels;

namespace NeuroKaraokeAvaloniaPlayer.Views;

public partial class SearchView : UserControl
{
    public SearchView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void OnSearchKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            await PerformSearch();
        }
    }

    private async Task PerformSearch()
    {
        if (DataContext is ViewModels.SearchViewModel vm)
        {
            await vm.Search();
        }
    }

    private async void OnResultDoubleTapped(object? sender, RoutedEventArgs e)
    {
        if (sender is DataGrid { SelectedItem: Models.Song song } &&
            DataContext is ViewModels.SearchViewModel vm)
        {
            vm.UpdateNowPlaying(song);
        }
    }
}