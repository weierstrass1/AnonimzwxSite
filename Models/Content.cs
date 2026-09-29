namespace AnonimzwxSite.Models;

/// <summary>One entry of unity.json / snes.json.</summary>
public class Content
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public List<string> Tags { get; set; } = [];
    /// <summary>YouTube links, .mp4/.webm clips, or images/GIFs (paths like "media/unity/demo.gif").</summary>
    public List<string> Media { get; set; } = [];
}

/// <summary>about.json</summary>
public class AboutInfo
{
    public string Headline { get; set; } = "";
    public List<string> Intro { get; set; } = [];
    public List<LinkItem> Links { get; set; } = [];
    public List<SkillGroup> Skills { get; set; } = [];
    public List<string> Highlights { get; set; } = [];
}

public class LinkItem
{
    public string Label { get; set; } = "";
    public string Url { get; set; } = "";
}

public class SkillGroup
{
    public string Group { get; set; } = "";
    public List<string> Items { get; set; } = [];
}
