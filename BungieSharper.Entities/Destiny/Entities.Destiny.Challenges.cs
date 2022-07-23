using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Challenges
{
    /// <summary>
    /// Represents the status and other related information for a challenge that is - or was - available to a player.
    /// A challenge is a bonus objective, generally tacked onto Quests or Activities, that provide additional variations on play.
    /// </summary>
    public class DestinyChallengeStatus
    {
        /// <summary>The progress - including completion status - of the active challenge.</summary>
        [JsonPropertyName("objective")]
        public Destiny.Quests.DestinyObjectiveProgress Objective { get; set; }
    }

    [JsonSerializable(typeof(DestinyChallengeStatus))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyChallengeStatusJsonContext : JsonSerializerContext { }
}