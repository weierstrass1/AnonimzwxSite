using System.Text.Json;
using AnonimzwxSite.Models;

namespace AnonimzwxSite.Services;

public class ProjectService
{
    private readonly Dictionary<string, List<Project>> _data;

    public ProjectService(IWebHostEnvironment env)
    {
        var path = Path.Combine(env.WebRootPath, "data", "projects.json");
        var json = File.ReadAllText(path);
        _data = JsonSerializer.Deserialize<Dictionary<string, List<Project>>>(
                    json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
    }

    public IReadOnlyList<Project> Get(string section) =>
        _data.TryGetValue(section, out var list) ? list : [];
}
