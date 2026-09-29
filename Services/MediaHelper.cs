using System.Web;

namespace AnonimzwxSite.Services;

public static class MediaHelper
{
    public static string? YouTubeId(string src)
    {
        if (!Uri.TryCreate(src, UriKind.Absolute, out var uri)) return null;
        var host = uri.Host.ToLowerInvariant();

        if (host == "youtu.be")
            return uri.AbsolutePath.Trim('/').Split('/')[0];

        if (host.EndsWith("youtube.com") || host.EndsWith("youtube-nocookie.com"))
        {
            var v = HttpUtility.ParseQueryString(uri.Query)["v"];
            if (!string.IsNullOrEmpty(v)) return v;

            var seg = uri.AbsolutePath.Trim('/').Split('/');
            if (seg.Length >= 2 && (seg[0] is "embed" or "shorts" or "live")) return seg[1];
        }
        return null;
    }

    public static bool IsVideoFile(string src) =>
        src.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) ||
        src.EndsWith(".webm", StringComparison.OrdinalIgnoreCase);
}
