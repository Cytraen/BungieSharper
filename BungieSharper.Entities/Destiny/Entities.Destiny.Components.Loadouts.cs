using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.Loadouts;

public class DestinyLoadoutsComponent
{
    [JsonPropertyName("loadouts")]
    public IEnumerable<Destiny.Components.Loadouts.DestinyLoadoutComponent> Loadouts { get; set; }
}

public class DestinyLoadoutComponent
{
    [JsonPropertyName("colorHash")]
    public uint ColorHash { get; set; }

    [JsonPropertyName("iconHash")]
    public uint IconHash { get; set; }

    [JsonPropertyName("nameHash")]
    public uint NameHash { get; set; }

    [JsonPropertyName("items")]
    public IEnumerable<Destiny.Components.Loadouts.DestinyLoadoutItemComponent> Items { get; set; }
}

public class DestinyLoadoutItemComponent
{
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; set; }

    [JsonPropertyName("plugItemHashes")]
    public IEnumerable<uint> PlugItemHashes { get; set; }
}