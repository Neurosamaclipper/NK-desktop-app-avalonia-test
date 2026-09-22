using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NeuroKaraokeAvaloniaPlayer.Models;
using NeuroKaraokeAvaloniaPlayer.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NeuroKaraokeAvaloniaPlayer.ViewModels;

public partial class RadioViewModel : ViewModelBase
{
    private readonly NeurokaraokeApiClient _apiClient;

    [ObservableProperty]
    private ObservableCollection<Song> _recentSongs = new ObservableCollection<Song>();

    [ObservableProperty]
    private bool _isLoading = false;

    [ObservableProperty]
    private string? _errorMessage;

    public RadioViewModel()
    {
        _apiClient = new NeurokaraokeApiClient();
        LoadRecentSongsAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    public async Task Refresh()
    {
        await LoadRecentSongsAsync();
    }

    private async Task LoadRecentSongsAsync()
    {
        IsLoading = true;
        ErrorMessage = null;
        try
        {

            var song = await _apiClient.GetRandomSongAsync();
            RecentSongs.Clear();
            if (song != null)
            {
                RecentSongs.Add(song);
            }

        }
        catch (Exception ex)
        {
            ErrorMessage = $"Failed to load radio: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }
}