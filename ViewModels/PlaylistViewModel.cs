using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NeuroKaraokeAvaloniaPlayer.Models;
using NeuroKaraokeAvaloniaPlayer.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NeuroKaraokeAvaloniaPlayer.ViewModels;

public partial class PlaylistViewModel : ViewModelBase
{
    private readonly NeurokaraokeApiClient _apiClient;

    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists = new ObservableCollection<Playlist>();

    [ObservableProperty]
    private Playlist? _selectedPlaylist;

    [ObservableProperty]
    private ObservableCollection<Song> _playlistSongs = new ObservableCollection<Song>();

    [ObservableProperty]
    private bool _canLoadPlaylist = false;

    public PlaylistViewModel()
    {
        _apiClient = new NeurokaraokeApiClient();
        LoadPlaylistsAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    public async Task Refresh()
    {
        await LoadPlaylistsAsync();
    }

    [RelayCommand]
    public async Task LoadSelectedPlaylist()
    {
        if (SelectedPlaylist == null)
            return;

        await LoadPlaylistSongs(SelectedPlaylist.Id);
    }

    private async Task LoadPlaylistsAsync()
    {
        try
        {
            var playlists = await _apiClient.GetPublicPlaylistsAsync();
            Playlists.Clear();
            foreach (var playlist in playlists)
            {
                Playlists.Add(playlist);
            }
        }
        catch
        {

        }
    }

    private async Task LoadPlaylistSongs(string playlistId)
    {
        try
        {
            var playlistDetails = await _apiClient.GetPlaylistDetailsAsync(playlistId);
            PlaylistSongs.Clear();
            if (playlistDetails?.Songs != null)
            {
                foreach (var song in playlistDetails.Songs)
                {
                    PlaylistSongs.Add(song);
                }
            }
        }
        catch
        {

        }
    }

    partial void OnSelectedPlaylistChanged(Playlist? value)
    {
        CanLoadPlaylist = value != null;
        if (value != null)
        {

            _ = LoadPlaylistSongs(value.Id);
        }
        else
        {
            PlaylistSongs.Clear();
        }
    }
}