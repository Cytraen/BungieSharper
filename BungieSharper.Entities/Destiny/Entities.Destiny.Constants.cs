using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Constants
{
    public class DestinyEnvironmentLocationMapping
    {
        /// <summary>The location that is revealed on the director by this mapping.</summary>
        [JsonPropertyName("locationHash")]
        public uint LocationHash { get; set; }

        /// <summary>A hint that the UI uses to figure out how this location is activated by the player.</summary>
        [JsonPropertyName("activationSource")]
        public string ActivationSource { get; set; }

        /// <summary>If this is populated, it is the item that you must possess for this location to be active because of this mapping. (theoretically, a location can have multiple mappings, and some might require an item while others don't)</summary>
        [JsonPropertyName("itemHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ItemHash { get; set; }

        /// <summary>If this is populated, this is an objective related to the location.</summary>
        [JsonPropertyName("objectiveHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ObjectiveHash { get; set; }

        /// <summary>If this is populated, this is the activity you have to be playing in order to see this location appear because of this mapping. (theoretically, a location can have multiple mappings, and some might require you to be in a specific activity when others don't)</summary>
        [JsonPropertyName("activityHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? ActivityHash { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyEnvironmentLocationMapping))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyEnvironmentLocationMappingJsonContext : JsonSerializerContext { }
#endif
}