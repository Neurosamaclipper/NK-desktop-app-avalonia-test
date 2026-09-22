using System.Collections.Generic;

namespace NeuroKaraokeAvaloniaPlayer.Models;

public class Song
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public List<string> OriginalArtists { get; set; } = new List<string>();
    public int Duration { get; set; }
    public int PlayCount { get; set; }
    public string? AudioUrl { get; set; }
    public string? PreviewUrl { get; set; }
    public string? AlbumArtUrl { get; set; }

    public string? Album { get; set; }
    public int Year { get; set; }
    public string? Genre { get; set; }
}