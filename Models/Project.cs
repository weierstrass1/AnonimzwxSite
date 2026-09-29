namespace AnonimzwxSite.Models;

public class Project
{
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public string Summary { get; set; } = "";
    public List<string> Tags { get; set; } = [];
    public List<MediaItem> Media { get; set; } = [];
}

/// <summary>Type: "youtube" (Src = video id), "clip" (Src = mp4/webm path), "image" (Src = webp path).</summary>
public class MediaItem
{
    public string Type { get; set; } = "image";
    public string Src { get; set; } = "";
    public string? Thumb { get; set; }
    public string? Caption { get; set; }
}
