using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Social.Friends
{
    public class BungieFriendListResponse
    {
        [JsonPropertyName("friends")]
        public IEnumerable<Social.Friends.BungieFriend> Friends { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(BungieFriendListResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class BungieFriendListResponseJsonContext : JsonSerializerContext { }
#endif

    public class BungieFriend
    {
        [JsonPropertyName("lastSeenAsMembershipId")]
        public long LastSeenAsMembershipId { get; set; }

        [JsonPropertyName("lastSeenAsBungieMembershipType")]
        public BungieMembershipType LastSeenAsBungieMembershipType { get; set; }

        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; set; }

        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public short? BungieGlobalDisplayNameCode { get; set; }

        [JsonPropertyName("onlineStatus")]
        public Social.Friends.PresenceStatus OnlineStatus { get; set; }

        [JsonPropertyName("onlineTitle")]
        public Social.Friends.PresenceOnlineStateFlags OnlineTitle { get; set; }

        [JsonPropertyName("relationship")]
        public Social.Friends.FriendRelationshipState Relationship { get; set; }

        [JsonPropertyName("bungieNetUser")]
        public User.GeneralUser BungieNetUser { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(BungieFriend))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class BungieFriendJsonContext : JsonSerializerContext { }
#endif

    public enum PresenceStatus : int
    {
        OfflineOrUnknown = 0,
        Online = 1
    }

    [System.Flags]
    public enum PresenceOnlineStateFlags : int
    {
        None = 0,
        Destiny1 = 1,
        Destiny2 = 2
    }

    public enum FriendRelationshipState : int
    {
        Unknown = 0,
        Friend = 1,
        IncomingRequest = 2,
        OutgoingRequest = 3
    }

    public class BungieFriendRequestListResponse
    {
        [JsonPropertyName("incomingRequests")]
        public IEnumerable<Social.Friends.BungieFriend> IncomingRequests { get; set; }

        [JsonPropertyName("outgoingRequests")]
        public IEnumerable<Social.Friends.BungieFriend> OutgoingRequests { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(BungieFriendRequestListResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class BungieFriendRequestListResponseJsonContext : JsonSerializerContext { }
#endif

    public enum PlatformFriendType : int
    {
        Unknown = 0,
        Xbox = 1,
        PSN = 2,
        Steam = 3
    }

    public class PlatformFriendResponse
    {
        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("platformFriends")]
        public IEnumerable<Social.Friends.PlatformFriend> PlatformFriends { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(PlatformFriendResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class PlatformFriendResponseJsonContext : JsonSerializerContext { }
#endif

    public class PlatformFriend
    {
        [JsonPropertyName("platformDisplayName")]
        public string PlatformDisplayName { get; set; }

        [JsonPropertyName("friendPlatform")]
        public Social.Friends.PlatformFriendType FriendPlatform { get; set; }

        [JsonPropertyName("destinyMembershipId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? DestinyMembershipId { get; set; }

        [JsonPropertyName("destinyMembershipType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DestinyMembershipType { get; set; }

        [JsonPropertyName("bungieNetMembershipId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? BungieNetMembershipId { get; set; }

        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; set; }

        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public short? BungieGlobalDisplayNameCode { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(PlatformFriend))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class PlatformFriendJsonContext : JsonSerializerContext { }
#endif
}