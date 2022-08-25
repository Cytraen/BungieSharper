using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Fireteam;

public enum FireteamDateRange : byte
{
    All = 0,
    Now = 1,
    TwentyFourHours = 2,
    FortyEightHours = 3,
    ThisWeek = 4
}

public enum FireteamPlatform : byte
{
    Any = 0,
    Playstation4 = 1,
    XboxOne = 2,
    Blizzard = 3,
    Steam = 4,
    Stadia = 5,
    Egs = 6
}

public enum FireteamPublicSearchOption : byte
{
    PublicAndPrivate = 0,
    PublicOnly = 1,
    PrivateOnly = 2
}

public enum FireteamSlotSearch : byte
{
    NoSlotRestriction = 0,
    HasOpenPlayerSlots = 1,
    HasOpenPlayerOrAltSlots = 2
}

public class FireteamSummary
{
    [JsonPropertyName("fireteamId")]
    public long FireteamId { get; set; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("platform")]
    public Fireteam.FireteamPlatform Platform { get; set; }

    [JsonPropertyName("activityType")]
    public int ActivityType { get; set; }

    [JsonPropertyName("isImmediate")]
    public bool IsImmediate { get; set; }

    [JsonPropertyName("scheduledTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ScheduledTime { get; set; }

    [JsonPropertyName("ownerMembershipId")]
    public long OwnerMembershipId { get; set; }

    [JsonPropertyName("playerSlotCount")]
    public int PlayerSlotCount { get; set; }

    [JsonPropertyName("alternateSlotCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? AlternateSlotCount { get; set; }

    [JsonPropertyName("availablePlayerSlotCount")]
    public int AvailablePlayerSlotCount { get; set; }

    [JsonPropertyName("availableAlternateSlotCount")]
    public int AvailableAlternateSlotCount { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonPropertyName("dateModified")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? DateModified { get; set; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("isValid")]
    public bool IsValid { get; set; }

    [JsonPropertyName("datePlayerModified")]
    public DateTime DatePlayerModified { get; set; }

    [JsonPropertyName("titleBeforeModeration")]
    public string TitleBeforeModeration { get; set; }
}

public class FireteamResponse
{
    [JsonPropertyName("Summary")]
    public Fireteam.FireteamSummary Summary { get; set; }

    [JsonPropertyName("Members")]
    public IEnumerable<Fireteam.FireteamMember> Members { get; set; }

    [JsonPropertyName("Alternates")]
    public IEnumerable<Fireteam.FireteamMember> Alternates { get; set; }
}

public class FireteamMember
{
    [JsonPropertyName("destinyUserInfo")]
    public Fireteam.FireteamUserInfoCard DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("dateJoined")]
    public DateTime DateJoined { get; set; }

    [JsonPropertyName("hasMicrophone")]
    public bool HasMicrophone { get; set; }

    [JsonPropertyName("lastPlatformInviteAttemptDate")]
    public DateTime LastPlatformInviteAttemptDate { get; set; }

    [JsonPropertyName("lastPlatformInviteAttemptResult")]
    public Fireteam.FireteamPlatformInviteResult LastPlatformInviteAttemptResult { get; set; }
}

public class FireteamUserInfoCard
{
    [JsonPropertyName("FireteamDisplayName")]
    public string FireteamDisplayName { get; set; }

    [JsonPropertyName("FireteamMembershipType")]
    public BungieMembershipType FireteamMembershipType { get; set; }

    /// <summary>A platform specific additional display name - ex: psn Real Name, bnet Unique Name, etc.</summary>
    [JsonPropertyName("supplementalDisplayName")]
    public string SupplementalDisplayName { get; set; }

    /// <summary>URL the Icon if available.</summary>
    [JsonPropertyName("iconPath")]
    public string IconPath { get; set; }

    /// <summary>If there is a cross save override in effect, this value will tell you the type that is overridding this one.</summary>
    [JsonPropertyName("crossSaveOverride")]
    public BungieMembershipType CrossSaveOverride { get; set; }

    /// <summary>
    /// The list of Membership Types indicating the platforms on which this Membership can be used.
    /// Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and its original membership type Cross Save Overridden = Empty list
    /// </summary>
    [JsonPropertyName("applicableMembershipTypes")]
    public IEnumerable<BungieMembershipType> ApplicableMembershipTypes { get; set; }

    /// <summary>If True, this is a public user membership.</summary>
    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; set; }

    /// <summary>Type of the membership. Not necessarily the native type.</summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    /// <summary>Membership ID as they user is known in the Accounts service</summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    /// <summary>Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.</summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    /// <summary>The bungie global display name, if set.</summary>
    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    /// <summary>The bungie global display name code, if set.</summary>
    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public short? BungieGlobalDisplayNameCode { get; set; }
}

public enum FireteamPlatformInviteResult : byte
{
    None = 0,
    Success = 1,
    AlreadyInFireteam = 2,
    Throttled = 3,
    ServiceError = 4
}