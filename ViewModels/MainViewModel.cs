using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NeuroKaraokeAvaloniaPlayer.ViewModels;

namespace NeuroKaraokeAvaloniaPlayer.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private object? _searchViewModel;

    [ObservableProperty]
    private object? _playlistViewModel;

    [ObservableProperty]
    private object? _radioViewModel;

    [ObservableProperty]
    private bool _showSearchView = true;

    [ObservableProperty]
    private bool _showPlaylistView = true;

    [ObservableProperty]
    private bool _showRadioView = true;

    public MainViewModel()
    {
        SearchViewModel = new SearchViewModel();
        PlaylistViewModel = new PlaylistViewModel();
        RadioViewModel = new RadioViewModel();
    }

    [RelayCommand]
    private void Exit()
    {

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop &&
            desktop.MainWindow is { } window)
        {
            window.Close();
        }
    }

    [RelayCommand]
    private void About()
    {

    }
}