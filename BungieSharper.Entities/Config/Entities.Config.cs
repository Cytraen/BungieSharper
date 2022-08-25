using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Config;

public class UserTheme
{
    [JsonPropertyName("userThemeId")]
    public int UserThemeId { get; set; }

    [JsonPropertyName("userThemeName")]
    public string UserThemeName { get; set; }

    [JsonPropertyName("userThemeDescription")]
    public string UserThemeDescription { get; set; }
}

public class GroupTheme
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("folder")]
    public string Folder { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}