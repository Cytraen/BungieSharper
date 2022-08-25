using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Entities;

public class EntityActionResult
{
    [JsonPropertyName("entityId")]
    public long EntityId { get; set; }

    [JsonPropertyName("result")]
    public Exceptions.PlatformErrorCodes Result { get; set; }
}