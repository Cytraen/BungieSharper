using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.Craftables;

public class DestinyCraftablesComponent
{
    /// <summary>A map of craftable item hashes to craftable item state components.</summary>
    [JsonPropertyName("craftables")]
    public Dictionary<uint, Destiny.Components.Craftables.DestinyCraftableComponent> Craftables { get; set; }

    /// <summary>The hash for the root presentation node definition of craftable item categories.</summary>
    [JsonPropertyName("craftingRootNodeHash")]
    public uint CraftingRootNodeHash { get; set; }
}

public class DestinyCraftableComponent
{
    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    /// <summary>If the requirements are not met for crafting this item, these will index into the list of failure strings.</summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public IEnumerable<int> FailedRequirementIndexes { get; set; }

    /// <summary>Plug item state for the crafting sockets.</summary>
    [JsonPropertyName("sockets")]
    public IEnumerable<Destiny.Components.Craftables.DestinyCraftableSocketComponent> Sockets { get; set; }
}

public class DestinyCraftableSocketComponent
{
    [JsonPropertyName("plugSetHash")]
    public uint PlugSetHash { get; set; }

    /// <summary>Unlock state for plugs in the socket plug set definition</summary>
    [JsonPropertyName("plugs")]
    public IEnumerable<Destiny.Components.Craftables.DestinyCraftableSocketPlugComponent> Plugs { get; set; }
}

public class DestinyCraftableSocketPlugComponent
{
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    /// <summary>Index into the unlock requirements to display failure descriptions</summary>
    [JsonPropertyName("failedRequirementIndexes")]
    public IEnumerable<int> FailedRequirementIndexes { get; set; }
}