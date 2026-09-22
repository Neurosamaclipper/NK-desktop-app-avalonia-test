using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NeuroKaraokeAvaloniaPlayer.Models;

namespace NeuroKaraokeAvaloniaPlayer.Services;

public class NeurokaraokeApiClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    private const string BaseUrl = "https://api.neurokaraoke.com";

    public string AudioBaseUrl => "storage.neurokaraoke.com/audio/";

    public NeurokaraokeApiClient()
    {
        _httpClient = new HttpClient();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<Song?> GetRandomSongAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/song/random");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Song>(json, _jsonOptions);
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<Song>> SearchSongsAsync(string query)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/song/search?q={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (JsonSerializer.Deserialize<SearchResponse>(json, _jsonOptions) is { } searchResponse)
            {
                return searchResponse.Results;
            }

            return new List<Song>();
        }
        catch
        {
            return new List<Song>();
        }
    }

    public async Task<Song?> GetSongDetailsAsync(string songId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/song/{songId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Song>(json, _jsonOptions);
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<Playlist>> GetPublicPlaylistsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/playlist/public");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (JsonSerializer.Deserialize<PlaylistsResponse>(json, _jsonOptions) is { } playlistsResponse)
            {
                return playlistsResponse.Playlists;
            }

            return new List<Playlist>();
        }
        catch
        {
            return new List<Playlist>();
        }
    }

    public async Task<Playlist?> GetPlaylistDetailsAsync(string playlistId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/playlist/{playlistId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Playlist>(json, _jsonOptions);
        }
        catch
        {
            return null;
        }
    }

    public async Task<Artist?> GetArtistDetailsAsync(string artistId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/artist/{artistId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Artist>(json, _jsonOptions);
        }
        catch
        {
            return null;
        }
    }

    private class SearchResponse
    {
        public List<Song> Results { get; set; } = new List<Song>();
    }

    private class PlaylistsResponse
    {
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}