using System.Collections.Generic;

namespace NeuroKaraokeAvaloniaPlayer.Models;

public class Artist
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? PictureUrl { get; set; }
    public int FollowerCount { get; set; }
    public int MonthlyListeners { get; set; }
    public List<string> Genres { get; set; } = new List<string>();

    public List<string> TopTrackIds { get; set; } = new List<string>();
}