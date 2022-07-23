using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Advanced
{
    public class AwaInitializeResponse
    {
        /// <summary>ID used to get the token. Present this ID to the user as it will identify this specific request on their device.</summary>
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; set; }

        /// <summary>True if the PUSH message will only be sent to the device that made this request.</summary>
        [JsonPropertyName("sentToSelf")]
        public bool SentToSelf { get; set; }
    }

    [JsonSerializable(typeof(AwaInitializeResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class AwaInitializeResponseJsonContext : JsonSerializerContext { }

    public class AwaPermissionRequested
    {
        /// <summary>Type of advanced write action.</summary>
        [JsonPropertyName("type")]
        public Destiny.Advanced.AwaType Type { get; set; }

        /// <summary>Item instance ID the action shall be applied to. This is optional for all but a new AwaType values. Rule of thumb is to provide the item instance ID if one is available.</summary>
        [JsonPropertyName("affectedItemId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? AffectedItemId { get; set; }

        /// <summary>Destiny membership type of the account to modify.</summary>
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }

        /// <summary>Destiny character ID, if applicable, that will be affected by the action.</summary>
        [JsonPropertyName("characterId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? CharacterId { get; set; }
    }

    [JsonSerializable(typeof(AwaPermissionRequested))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class AwaPermissionRequestedJsonContext : JsonSerializerContext { }

    public enum AwaType : int
    {
        None = 0,

        /// <summary>Insert plugs into sockets.</summary>
        InsertPlugs = 1
    }

    public class AwaUserResponse
    {
        /// <summary>Indication of the selection the user has made (Approving or rejecting the action)</summary>
        [JsonPropertyName("selection")]
        public Destiny.Advanced.AwaUserSelection Selection { get; set; }

        /// <summary>Correlation ID of the request</summary>
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; set; }

        /// <summary>Secret nonce received via the PUSH notification.</summary>
        [JsonPropertyName("nonce")]
        public IEnumerable<byte> Nonce { get; set; }
    }

    [JsonSerializable(typeof(AwaUserResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class AwaUserResponseJsonContext : JsonSerializerContext { }

    public enum AwaUserSelection : int
    {
        None = 0,
        Rejected = 1,
        Approved = 2
    }

    public class AwaAuthorizationResult
    {
        /// <summary>Indication of how the user responded to the request. If the value is "Approved" the actionToken will contain the token that can be presented when performing the advanced write action.</summary>
        [JsonPropertyName("userSelection")]
        public Destiny.Advanced.AwaUserSelection UserSelection { get; set; }

        [JsonPropertyName("responseReason")]
        public Destiny.Advanced.AwaResponseReason ResponseReason { get; set; }

        /// <summary>Message to the app developer to help understand the response.</summary>
        [JsonPropertyName("developerNote")]
        public string DeveloperNote { get; set; }

        /// <summary>Credential used to prove the user authorized an advanced write action.</summary>
        [JsonPropertyName("actionToken")]
        public string ActionToken { get; set; }

        /// <summary>This token may be used to perform the requested action this number of times, at a maximum. If this value is 0, then there is no limit.</summary>
        [JsonPropertyName("maximumNumberOfUses")]
        public int MaximumNumberOfUses { get; set; }

        /// <summary>Time, UTC, when token expires.</summary>
        [JsonPropertyName("validUntil")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public System.DateTime? ValidUntil { get; set; }

        /// <summary>Advanced Write Action Type from the permission request.</summary>
        [JsonPropertyName("type")]
        public Destiny.Advanced.AwaType Type { get; set; }

        /// <summary>MembershipType from the permission request.</summary>
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    [JsonSerializable(typeof(AwaAuthorizationResult))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class AwaAuthorizationResultJsonContext : JsonSerializerContext { }

    public enum AwaResponseReason : int
    {
        None = 0,

        /// <summary>User provided an answer</summary>
        Answered = 1,

        /// <summary>The HTTP request timed out, a new request may be made and an answer may still be provided.</summary>
        TimedOut = 2,

        /// <summary>This request was replaced by another request.</summary>
        Replaced = 3
    }
}