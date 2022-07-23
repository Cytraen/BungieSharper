using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Components
{
    /// <summary>
    /// The base class for any component-returning object that may need to indicate information about the state of the component being returned.
    /// </summary>
    public class ComponentResponse
    {
        [JsonPropertyName("privacy")]
        public Components.ComponentPrivacySetting Privacy { get; set; }

        /// <summary>If true, this component is disabled.</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Disabled { get; set; }
    }

    [JsonSerializable(typeof(ComponentResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ComponentResponseJsonContext : JsonSerializerContext { }

    /// <summary>
    /// A set of flags for reason(s) why the component populated in the way that it did. Inspect the individual flags for the reasons.
    /// </summary>
    public enum ComponentPrivacySetting : int
    {
        None = 0,
        Public = 1,
        Private = 2
    }
}