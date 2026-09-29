using System.Text.Json;
using AnonimzwxSite.Models;

namespace AnonimzwxSite.Services;

/// <summary>
/// Reads the JSON files in wwwroot/data on every request, so edits show up on refresh
/// without restarting the app. JSON comments and trailing commas are allowed.
/// </summary>
public class ContentService(IWebHostEnvironment env, ILogger<ContentService> logger)
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public AboutInfo About() => Load<AboutInfo>("about.json");
    public List<Project> Unity() => Load<List<Project>>("unity.json");
    public List<Project> Snes() => Load<List<Project>>("snes.json");

    private T Load<T>(string file) where T : new()
    {
        try
        {
            var path = Path.Combine(env.WebRootPath, "data", file);
            return JsonSerializer.Deserialize<T>(File.ReadAllText(path), Options) ?? new T();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Could not read wwwroot/data/{File}. Check the JSON syntax.", file);
            return new T();
        }
    }
}
