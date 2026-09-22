using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NeuroKaraokeAvaloniaPlayer.ViewModels;

namespace NeuroKaraokeAvaloniaPlayer.Views;

public partial class PlaylistView : UserControl
{
    public PlaylistView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void OnPlaylistDoubleTapped(object? sender, RoutedEventArgs e)
    {
        if (sender is ListBox { SelectedItem: Models.Playlist playlist } &&
            DataContext is ViewModels.PlaylistViewModel vm)
        {
            await vm.LoadSelectedPlaylist();
        }
    }

    private async void OnSongDoubleTapped(object? sender, RoutedEventArgs e)
    {
        if (sender is DataGrid { SelectedItem: Models.Song song } &&
            DataContext is ViewModels.PlaylistViewModel vm)
        {

        }
    }
}