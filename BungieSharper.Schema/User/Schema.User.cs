using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.User
{
    /// <summary>
    /// Very basic info about a user as returned by the Account server.
    /// </summary>
    public class UserMembership
    {
        /// <summary>Type of the membership. Not necessarily the native type.</summary>
        public BungieMembershipType membershipType { get; set; }

        /// <summary>Membership ID as they user is known in the Accounts service</summary>
        public long membershipId { get; set; }

        /// <summary>Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.</summary>
        public string displayName { get; set; }
    }

    /// <summary>
    /// Very basic info about a user as returned by the Account server, but including CrossSave information. Do NOT use as a request contract.
    /// </summary>
    public class CrossSaveUserMembership
    {
        /// <summary>If there is a cross save override in effect, this value will tell you the type that is overridding this one.</summary>
        public BungieMembershipType crossSaveOverride { get; set; }

        /// <summary>
        /// The list of Membership Types indicating the platforms on which this Membership can be used.
        ///  Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and its original membership type Cross Save Overridden = Empty list
        /// </summary>
        public IEnumerable<BungieMembershipType> applicableMembershipTypes { get; set; }

        /// <summary>If True, this is a public user membership.</summary>
        public bool isPublic { get; set; }

        /// <summary>Type of the membership. Not necessarily the native type.</summary>
        public BungieMembershipType membershipType { get; set; }

        /// <summary>Membership ID as they user is known in the Accounts service</summary>
        public long membershipId { get; set; }

        /// <summary>Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.</summary>
        public string displayName { get; set; }
    }

    /// <summary>
    /// This contract supplies basic information commonly used to display a minimal amount of information about a user. Take care to not add more properties here unless the property applies in all (or at least the majority) of the situations where UserInfoCard is used. Avoid adding game specific or platform specific details here. In cases where UserInfoCard is a subset of the data needed in a contract, use UserInfoCard as a property of other contracts.
    /// </summary>
    public class UserInfoCard
    {
        /// <summary>A platform specific additional display name - ex: psn Real Name, bnet Unique Name, etc.</summary>
        public string supplementalDisplayName { get; set; }

        /// <summary>URL the Icon if available.</summary>
        public string iconPath { get; set; }

        /// <summary>If there is a cross save override in effect, this value will tell you the type that is overridding this one.</summary>
        public BungieMembershipType crossSaveOverride { get; set; }

        /// <summary>
        /// The list of Membership Types indicating the platforms on which this Membership can be used.
        ///  Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and its original membership type Cross Save Overridden = Empty list
        /// </summary>
        public IEnumerable<BungieMembershipType> applicableMembershipTypes { get; set; }

        /// <summary>If True, this is a public user membership.</summary>
        public bool isPublic { get; set; }

        /// <summary>Type of the membership. Not necessarily the native type.</summary>
        public BungieMembershipType membershipType { get; set; }

        /// <summary>Membership ID as they user is known in the Accounts service</summary>
        public long membershipId { get; set; }

        /// <summary>Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.</summary>
        public string displayName { get; set; }
    }

    public class GeneralUser
    {
        public long membershipId { get; set; }

        public string uniqueName { get; set; }

        public string normalizedName { get; set; }

        public string displayName { get; set; }

        public int profilePicture { get; set; }

        public int profileTheme { get; set; }

        public int userTitle { get; set; }

        public long successMessageFlags { get; set; }

        public bool isDeleted { get; set; }

        public string about { get; set; }

        public DateTime? firstAccess { get; set; }

        public DateTime? lastUpdate { get; set; }

        public long? legacyPortalUID { get; set; }

        public User.UserToUserContext context { get; set; }

        public string psnDisplayName { get; set; }

        public string xboxDisplayName { get; set; }

        public string fbDisplayName { get; set; }

        public bool? showActivity { get; set; }

        public string locale { get; set; }

        public bool localeInheritDefault { get; set; }

        public long? lastBanReportId { get; set; }

        public bool showGroupMessaging { get; set; }

        public string profilePicturePath { get; set; }

        public string profilePictureWidePath { get; set; }

        public string profileThemeName { get; set; }

        public string userTitleDisplay { get; set; }

        public string statusText { get; set; }

        public DateTime statusDate { get; set; }

        public DateTime? profileBanExpire { get; set; }

        public string blizzardDisplayName { get; set; }

        public string steamDisplayName { get; set; }

        public string stadiaDisplayName { get; set; }

        public string twitchDisplayName { get; set; }
    }

    public class UserToUserContext
    {
        public bool isFollowing { get; set; }

        public Ignores.IgnoreResponse ignoreStatus { get; set; }

        public DateTime? globalIgnoreEndDate { get; set; }
    }

    public class UserMembershipData
    {
        /// <summary>this allows you to see destiny memberships that are visible and linked to this account (regardless of whether or not they have characters on the world server)</summary>
        public IEnumerable<GroupsV2.GroupUserInfoCard> destinyMemberships { get; set; }

        /// <summary>
        /// If this property is populated, it will have the membership ID of the account considered to be "primary" in this user's cross save relationship.
        ///  If null, this user has no cross save relationship, nor primary account.
        /// </summary>
        public long? primaryMembershipId { get; set; }

        public User.GeneralUser bungieNetUser { get; set; }
    }

    public class HardLinkedUserMembership
    {
        public BungieMembershipType membershipType { get; set; }

        public long membershipId { get; set; }

        public BungieMembershipType CrossSaveOverriddenType { get; set; }

        public long? CrossSaveOverriddenMembershipId { get; set; }
    }

    /// <summary>
    /// The set of all email subscription/opt-in settings and definitions.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>Keyed by the name identifier of the opt-in definition.</summary>
        public Dictionary<string, User.EmailOptInDefinition> optInDefinitions { get; set; }

        /// <summary>Keyed by the name identifier of the Subscription definition.</summary>
        public Dictionary<string, User.EmailSubscriptionDefinition> subscriptionDefinitions { get; set; }

        /// <summary>Keyed by the name identifier of the View definition.</summary>
        public Dictionary<string, User.EmailViewDefinition> views { get; set; }
    }

    /// <summary>
    /// Defines a single opt-in category: a wide-scoped permission to send emails for the subject related to the opt-in.
    /// </summary>
    public class EmailOptInDefinition
    {
        /// <summary>The unique identifier for this opt-in category.</summary>
        public string name { get; set; }

        /// <summary>The flag value for this opt-in category. For historical reasons, this is defined as a flags enum.</summary>
        public User.OptInFlags value { get; set; }

        /// <summary>If true, this opt-in setting should be set by default in situations where accounts are created without explicit choices about what they're opting into.</summary>
        public bool setByDefault { get; set; }

        /// <summary>Information about the dependent subscriptions for this opt-in.</summary>
        public IEnumerable<User.EmailSubscriptionDefinition> dependentSubscriptions { get; set; }
    }

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
        public string name { get; set; }

        /// <summary>A dictionary of localized text for the EMail Opt-in setting, keyed by the locale.</summary>
        public Dictionary<string, User.EMailSettingSubscriptionLocalization> localization { get; set; }

        /// <summary>The bitflag value for this subscription. Should be a unique power of two value.</summary>
        public long value { get; set; }
    }

    /// <summary>
    /// Localized text relevant to a given EMail setting in a given localization.
    /// </summary>
    public class EMailSettingLocalization
    {
        public string title { get; set; }

        public string description { get; set; }
    }

    /// <summary>
    /// Localized text relevant to a given EMail setting in a given localization. Extra settings specifically for subscriptions.
    /// </summary>
    public class EMailSettingSubscriptionLocalization
    {
        public string unknownUserDescription { get; set; }

        public string registeredUserDescription { get; set; }

        public string unregisteredUserDescription { get; set; }

        public string unknownUserActionText { get; set; }

        public string knownUserActionText { get; set; }

        public string title { get; set; }

        public string description { get; set; }
    }

    /// <summary>
    /// Represents a data-driven view for Email settings. Web/Mobile UI can use this data to show new EMail settings consistently without further manual work.
    /// </summary>
    public class EmailViewDefinition
    {
        /// <summary>The identifier for this view.</summary>
        public string name { get; set; }

        /// <summary>The ordered list of settings to show in this view.</summary>
        public IEnumerable<User.EmailViewDefinitionSetting> viewSettings { get; set; }
    }

    public class EmailViewDefinitionSetting
    {
        /// <summary>The identifier for this UI Setting, which can be used to relate it to custom strings or other data as desired.</summary>
        public string name { get; set; }

        /// <summary>A dictionary of localized text for the EMail setting, keyed by the locale.</summary>
        public Dictionary<string, User.EMailSettingLocalization> localization { get; set; }

        /// <summary>If true, this setting should be set by default if the user hasn't chosen whether it's set or cleared yet.</summary>
        public bool setByDefault { get; set; }

        /// <summary>The OptInFlags value to set or clear if this setting is set or cleared in the UI. It is the aggregate of all underlying opt-in flags related to this setting.</summary>
        public User.OptInFlags optInAggregateValue { get; set; }

        /// <summary>The subscriptions to show as children of this setting, if any.</summary>
        public IEnumerable<User.EmailSubscriptionDefinition> subscriptions { get; set; }
    }
}