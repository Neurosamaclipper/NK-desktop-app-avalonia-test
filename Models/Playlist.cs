using System.Collections.Generic;

namespace NeuroKaraokeAvaloniaPlayer.Models;

public class Playlist
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? CoverArtUrl { get; set; }
    public int SongCount { get; set; }
    public int PlayCount { get; set; }
    public int FavoriteCount { get; set; }
    public List<string> Tags { get; set; } = new List<string>();

    public List<Song> Songs { get; set; } = new List<Song>();
}