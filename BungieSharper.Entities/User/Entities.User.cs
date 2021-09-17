using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.User
{
    /// <summary>
    /// Very basic info about a user as returned by the Account server.
    /// </summary>
    public class UserMembership
    {
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

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(UserMembership))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class UserMembershipJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// Very basic info about a user as returned by the Account server, but including CrossSave information. Do NOT use as a request contract.
    /// </summary>
    public class CrossSaveUserMembership
    {
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

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(CrossSaveUserMembership))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class CrossSaveUserMembershipJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// This contract supplies basic information commonly used to display a minimal amount of information about a user. Take care to not add more properties here unless the property applies in all (or at least the majority) of the situations where UserInfoCard is used. Avoid adding game specific or platform specific details here. In cases where UserInfoCard is a subset of the data needed in a contract, use UserInfoCard as a property of other contracts.
    /// </summary>
    public class UserInfoCard
    {
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

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(UserInfoCard))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class UserInfoCardJsonContext : JsonSerializerContext { }
#endif

    public class GeneralUser
    {
        [JsonPropertyName("membershipId")]
        public long MembershipId { get; set; }

        [JsonPropertyName("uniqueName")]
        public string UniqueName { get; set; }

        [JsonPropertyName("normalizedName")]
        public string NormalizedName { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("profilePicture")]
        public int ProfilePicture { get; set; }

        [JsonPropertyName("profileTheme")]
        public int ProfileTheme { get; set; }

        [JsonPropertyName("userTitle")]
        public int UserTitle { get; set; }

        [JsonPropertyName("successMessageFlags")]
        public long SuccessMessageFlags { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("firstAccess")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? FirstAccess { get; set; }

        [JsonPropertyName("lastUpdate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? LastUpdate { get; set; }

        [JsonPropertyName("legacyPortalUID")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? LegacyPortalUID { get; set; }

        [JsonPropertyName("context")]
        public User.UserToUserContext Context { get; set; }

        [JsonPropertyName("psnDisplayName")]
        public string PsnDisplayName { get; set; }

        [JsonPropertyName("xboxDisplayName")]
        public string XboxDisplayName { get; set; }

        [JsonPropertyName("fbDisplayName")]
        public string FbDisplayName { get; set; }

        [JsonPropertyName("showActivity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowActivity { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("localeInheritDefault")]
        public bool LocaleInheritDefault { get; set; }

        [JsonPropertyName("lastBanReportId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? LastBanReportId { get; set; }

        [JsonPropertyName("showGroupMessaging")]
        public bool ShowGroupMessaging { get; set; }

        [JsonPropertyName("profilePicturePath")]
        public string ProfilePicturePath { get; set; }

        [JsonPropertyName("profilePictureWidePath")]
        public string ProfilePictureWidePath { get; set; }

        [JsonPropertyName("profileThemeName")]
        public string ProfileThemeName { get; set; }

        [JsonPropertyName("userTitleDisplay")]
        public string UserTitleDisplay { get; set; }

        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        [JsonPropertyName("statusDate")]
        public DateTime StatusDate { get; set; }

        [JsonPropertyName("profileBanExpire")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ProfileBanExpire { get; set; }

        [JsonPropertyName("blizzardDisplayName")]
        public string BlizzardDisplayName { get; set; }

        [JsonPropertyName("steamDisplayName")]
        public string SteamDisplayName { get; set; }

        [JsonPropertyName("stadiaDisplayName")]
        public string StadiaDisplayName { get; set; }

        [JsonPropertyName("twitchDisplayName")]
        public string TwitchDisplayName { get; set; }

        [JsonPropertyName("cachedBungieGlobalDisplayName")]
        public string CachedBungieGlobalDisplayName { get; set; }

        [JsonPropertyName("cachedBungieGlobalDisplayNameCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public short? CachedBungieGlobalDisplayNameCode { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(GeneralUser))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class GeneralUserJsonContext : JsonSerializerContext { }
#endif

    public class UserToUserContext
    {
        [JsonPropertyName("isFollowing")]
        public bool IsFollowing { get; set; }

        [JsonPropertyName("ignoreStatus")]
        public Ignores.IgnoreResponse IgnoreStatus { get; set; }

        [JsonPropertyName("globalIgnoreEndDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? GlobalIgnoreEndDate { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(UserToUserContext))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class UserToUserContextJsonContext : JsonSerializerContext { }
#endif

    public class UserMembershipData
    {
        /// <summary>this allows you to see destiny memberships that are visible and linked to this account (regardless of whether or not they have characters on the world server)</summary>
        [JsonPropertyName("destinyMemberships")]
        public IEnumerable<GroupsV2.GroupUserInfoCard> DestinyMemberships { get; set; }

        /// <summary>
        /// If this property is populated, it will have the membership ID of the account considered to be "primary" in this user's cross save relationship.
        /// If null, this user has no cross save relationship, nor primary account.
        /// </summary>
        [JsonPropertyName("primaryMembershipId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? PrimaryMembershipId { get; set; }

        [JsonPropertyName("bungieNetUser")]
        public User.GeneralUser BungieNetUser { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(UserMembershipData))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class UserMembershipDataJsonContext : JsonSerializerContext { }
#endif

    public class HardLinkedUserMembership
    {
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }

        [JsonPropertyName("membershipId")]
        public long MembershipId { get; set; }

        [JsonPropertyName("CrossSaveOverriddenType")]
        public BungieMembershipType CrossSaveOverriddenType { get; set; }

        [JsonPropertyName("CrossSaveOverriddenMembershipId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? CrossSaveOverriddenMembershipId { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(HardLinkedUserMembership))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class HardLinkedUserMembershipJsonContext : JsonSerializerContext { }
#endif

    public class UserSearchResponse
    {
        [JsonPropertyName("searchResults")]
        public IEnumerable<User.UserSearchResponseDetail> SearchResults { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(UserSearchResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class UserSearchResponseJsonContext : JsonSerializerContext { }
#endif

    public class UserSearchResponseDetail
    {
        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; set; }

        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public short? BungieGlobalDisplayNameCode { get; set; }

        [JsonPropertyName("bungieNetMembershipId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? BungieNetMembershipId { get; set; }

        [JsonPropertyName("destinyMemberships")]
        public IEnumerable<User.UserInfoCard> DestinyMemberships { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(UserSearchResponseDetail))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class UserSearchResponseDetailJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// The set of all email subscription/opt-in settings and definitions.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>Keyed by the name identifier of the opt-in definition.</summary>
        [JsonPropertyName("optInDefinitions")]
        public Dictionary<string, User.EmailOptInDefinition> OptInDefinitions { get; set; }

        /// <summary>Keyed by the name identifier of the Subscription definition.</summary>
        [JsonPropertyName("subscriptionDefinitions")]
        public Dictionary<string, User.EmailSubscriptionDefinition> SubscriptionDefinitions { get; set; }

        /// <summary>Keyed by the name identifier of the View definition.</summary>
        [JsonPropertyName("views")]
        public Dictionary<string, User.EmailViewDefinition> Views { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(EmailSettings))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class EmailSettingsJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// Defines a single opt-in category: a wide-scoped permission to send emails for the subject related to the opt-in.
    /// </summary>
    public class EmailOptInDefinition
    {
        /// <summary>The unique identifier for this opt-in category.</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>The flag value for this opt-in category. For historical reasons, this is defined as a flags enum.</summary>
        [JsonPropertyName("value")]
        public User.OptInFlags Value { get; set; }

        /// <summary>If true, this opt-in setting should be set by default in situations where accounts are created without explicit choices about what they're opting into.</summary>
        [JsonPropertyName("setByDefault")]
        public bool SetByDefault { get; set; }

        /// <summary>Information about the dependent subscriptions for this opt-in.</summary>
        [JsonPropertyName("dependentSubscriptions")]
        public IEnumerable<User.EmailSubscriptionDefinition> DependentSubscriptions { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(EmailOptInDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class EmailOptInDefinitionJsonContext : JsonSerializerContext { }
#endif

    [Flags]
    public enum OptInFlags : long
    {
        None = 0,
        Newsletter = 1,
        System = 2,
        Marketing = 4,
        UserResearch = 8,
        CustomerService = 16,
        Social = 32,
        PlayTests = 64,
        PlayTestsLocal = 128,
        Careers = 256
    }

    /// <summary>
    /// Defines a single subscription: permission to send emails for a specific, focused subject (generally timeboxed, such as for a specific release of a product or feature).
    /// </summary>
    public class EmailSubscriptionDefinition
    {
        /// <summary>The unique identifier for this subscription.</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>A dictionary of localized text for the EMail Opt-in setting, keyed by the locale.</summary>
        [JsonPropertyName("localization")]
        public Dictionary<string, User.EMailSettingSubscriptionLocalization> Localization { get; set; }

        /// <summary>The bitflag value for this subscription. Should be a unique power of two value.</summary>
        [JsonPropertyName("value")]
        public long Value { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(EmailSubscriptionDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class EmailSubscriptionDefinitionJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// Localized text relevant to a given EMail setting in a given localization.
    /// </summary>
    public class EMailSettingLocalization
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(EMailSettingLocalization))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class EMailSettingLocalizationJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// Localized text relevant to a given EMail setting in a given localization. Extra settings specifically for subscriptions.
    /// </summary>
    public class EMailSettingSubscriptionLocalization
    {
        [JsonPropertyName("unknownUserDescription")]
        public string UnknownUserDescription { get; set; }

        [JsonPropertyName("registeredUserDescription")]
        public string RegisteredUserDescription { get; set; }

        [JsonPropertyName("unregisteredUserDescription")]
        public string UnregisteredUserDescription { get; set; }

        [JsonPropertyName("unknownUserActionText")]
        public string UnknownUserActionText { get; set; }

        [JsonPropertyName("knownUserActionText")]
        public string KnownUserActionText { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(EMailSettingSubscriptionLocalization))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class EMailSettingSubscriptionLocalizationJsonContext : JsonSerializerContext { }
#endif

    /// <summary>
    /// Represents a data-driven view for Email settings. Web/Mobile UI can use this data to show new EMail settings consistently without further manual work.
    /// </summary>
    public class EmailViewDefinition
    {
        /// <summary>The identifier for this view.</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>The ordered list of settings to show in this view.</summary>
        [JsonPropertyName("viewSettings")]
        public IEnumerable<User.EmailViewDefinitionSetting> ViewSettings { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(EmailViewDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class EmailViewDefinitionJsonContext : JsonSerializerContext { }
#endif

    public class EmailViewDefinitionSetting
    {
        /// <summary>The identifier for this UI Setting, which can be used to relate it to custom strings or other data as desired.</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>A dictionary of localized text for the EMail setting, keyed by the locale.</summary>
        [JsonPropertyName("localization")]
        public Dictionary<string, User.EMailSettingLocalization> Localization { get; set; }

        /// <summary>If true, this setting should be set by default if the user hasn't chosen whether it's set or cleared yet.</summary>
        [JsonPropertyName("setByDefault")]
        public bool SetByDefault { get; set; }

        /// <summary>The OptInFlags value to set or clear if this setting is set or cleared in the UI. It is the aggregate of all underlying opt-in flags related to this setting.</summary>
        [JsonPropertyName("optInAggregateValue")]
        public User.OptInFlags OptInAggregateValue { get; set; }

        /// <summary>The subscriptions to show as children of this setting, if any.</summary>
        [JsonPropertyName("subscriptions")]
        public IEnumerable<User.EmailSubscriptionDefinition> Subscriptions { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(EmailViewDefinitionSetting))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class EmailViewDefinitionSettingJsonContext : JsonSerializerContext { }
#endif
}