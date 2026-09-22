using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NeuroKaraokeAvaloniaPlayer.Models;
using NeuroKaraokeAvaloniaPlayer.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NeuroKaraokeAvaloniaPlayer.ViewModels;

public partial class SearchViewModel : ViewModelBase
{
    private readonly NeurokaraokeApiClient _apiClient;
    private readonly DispatcherTimer _searchTimer;
    private string _currentSearchQuery = string.Empty;

    [ObservableProperty]
    private string _searchQuery = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Song> _searchResults = new ObservableCollection<Song>();

    [ObservableProperty]
    private bool _isSearchEnabled = true;

    [ObservableProperty]
    private string _nowPlayingDisplay = string.Empty;

    [ObservableProperty]
    private bool _canPlayNowPlaying = false;

    public SearchViewModel()
    {
        _apiClient = new NeurokaraokeApiClient();
        _searchTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(300) };
        _searchTimer.Tick += async (s, e) => await PerformSearch();
    }

    [RelayCommand]
    public async Task Search()
    {
        await PerformSearch();
    }

    private async Task PerformSearch()
    {
        if (!IsSearchEnabled)
            return;

        IsSearchEnabled = false;
        try
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                SearchResults.Clear();
                NowPlayingDisplay = string.Empty;
                CanPlayNowPlaying = false;
                return;
            }

            _currentSearchQuery = SearchQuery;
            var results = await _apiClient.SearchSongsAsync(SearchQuery);
            SearchResults.Clear();
            foreach (var song in results)
            {
                SearchResults.Add(song);
            }
        }
        finally
        {
            IsSearchEnabled = true;
        }
    }

    [RelayCommand]
    public async Task PlayNowPlaying()
    {

    }

    public void UpdateNowPlaying(Song song)
    {
        if (song == null)
        {
            NowPlayingDisplay = string.Empty;
            CanPlayNowPlaying = false;
            return;
        }

        var artists = string.Join(", ", song.OriginalArtists);
        NowPlayingDisplay = $"{song.Title} by {artists}";
        CanPlayNowPlaying = true;
    }

    partial void OnSearchQueryChanged(string value)
    {
        _searchTimer.Stop();
        _searchTimer.Start();
    }
}