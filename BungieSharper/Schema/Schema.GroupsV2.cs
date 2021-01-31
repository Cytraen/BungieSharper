using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.GroupsV2
{
    public class GroupUserInfoCard
    {
        /// <summary>This will be the display name the clan server last saw the user as. If the account is an active cross save override, this will be the display name to use. Otherwise, this will match the displayName property.</summary>
        public string LastSeenDisplayName { get; set; }
        /// <summary>The platform of the LastSeenDisplayName</summary>
        public Schema.BungieMembershipType LastSeenDisplayNameType { get; set; }
        /// <summary>A platform specific additional display name - ex: psn Real Name, bnet Unique Name, etc.</summary>
        public string supplementalDisplayName { get; set; }
        /// <summary>URL the Icon if available.</summary>
        public string iconPath { get; set; }
        /// <summary>If there is a cross save override in effect, this value will tell you the type that is overridding this one.</summary>
        public Schema.BungieMembershipType crossSaveOverride { get; set; }
        /// <summary>
        /// The list of Membership Types indicating the platforms on which this Membership can be used.
        ///  Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and its original membership type Cross Save Overridden = Empty list
        /// </summary>
        public IEnumerable<Schema.BungieMembershipType> applicableMembershipTypes { get; set; }
        /// <summary>If True, this is a public user membership.</summary>
        public bool isPublic { get; set; }
        /// <summary>Type of the membership. Not necessarily the native type.</summary>
        public Schema.BungieMembershipType membershipType { get; set; }
        /// <summary>Membership ID as they user is known in the Accounts service</summary>
        public long membershipId { get; set; }
        /// <summary>Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.</summary>
        public string displayName { get; set; }
    }

    public class GroupResponse
    {
        public Schema.GroupsV2.GroupV2 detail { get; set; }
        public Schema.GroupsV2.GroupMember founder { get; set; }
        public IEnumerable<long> alliedIds { get; set; }
        public Schema.GroupsV2.GroupV2 parentGroup { get; set; }
        public Schema.GroupsV2.GroupAllianceStatus allianceStatus { get; set; }
        public int groupJoinInviteCount { get; set; }
        /// <summary>A convenience property that indicates if every membership you (the current user) have that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.</summary>
        public bool currentUserMembershipsInactiveForDestiny { get; set; }
        /// <summary>This property will be populated if the authenticated user is a member of the group. Note that because of account linking, a user can sometimes be part of a clan more than once. As such, this returns the highest member type available.</summary>
        public Dictionary<Schema.BungieMembershipType, Schema.GroupsV2.GroupMember> currentUserMemberMap { get; set; }
        /// <summary>This property will be populated if the authenticated user is an applicant or has an outstanding invitation to join. Note that because of account linking, a user can sometimes be part of a clan more than once.</summary>
        public Dictionary<Schema.BungieMembershipType, Schema.GroupsV2.GroupPotentialMember> currentUserPotentialMemberMap { get; set; }
    }

    public class GroupV2
    {
        public long groupId { get; set; }
        public string name { get; set; }
        public Schema.GroupsV2.GroupType groupType { get; set; }
        public long membershipIdCreated { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }
        public string about { get; set; }
        public IEnumerable<string> tags { get; set; }
        public int memberCount { get; set; }
        public bool isPublic { get; set; }
        public bool isPublicTopicAdminOnly { get; set; }
        public string motto { get; set; }
        public bool allowChat { get; set; }
        public bool isDefaultPostPublic { get; set; }
        public Schema.GroupsV2.ChatSecuritySetting chatSecurity { get; set; }
        public string locale { get; set; }
        public int avatarImageIndex { get; set; }
        public Schema.GroupsV2.GroupHomepage homepage { get; set; }
        public Schema.GroupsV2.MembershipOption membershipOption { get; set; }
        public Schema.GroupsV2.GroupPostPublicity defaultPublicity { get; set; }
        public string theme { get; set; }
        public string bannerPath { get; set; }
        public string avatarPath { get; set; }
        public long conversationId { get; set; }
        public bool enableInvitationMessagingForAdmins { get; set; }
        public DateTime? banExpireDate { get; set; }
        public Schema.GroupsV2.GroupFeatures features { get; set; }
        public Schema.GroupsV2.GroupV2ClanInfoAndInvestment clanInfo { get; set; }
    }

    public enum GroupType
    {
        General = 0,
        Clan = 1
    }

    public enum ChatSecuritySetting
    {
        Group = 0,
        Admins = 1
    }

    public enum GroupHomepage
    {
        Wall = 0,
        Forum = 1,
        AllianceForum = 2
    }

    public enum MembershipOption
    {
        Reviewed = 0,
        Open = 1,
        Closed = 2
    }

    public enum GroupPostPublicity
    {
        Public = 0,
        Alliance = 1,
        Private = 2
    }

    public class GroupFeatures
    {
        public int maximumMembers { get; set; }
        /// <summary>Maximum number of groups of this type a typical membership may join. For example, a user may join about 50 General groups with their Bungie.net account. They may join one clan per Destiny membership.</summary>
        public int maximumMembershipsOfGroupType { get; set; }
        public Schema.GroupsV2.Capabilities capabilities { get; set; }
        public IEnumerable<Schema.BungieMembershipType> membershipTypes { get; set; }
        /// <summary>
        /// Minimum Member Level allowed to invite new members to group
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        public bool invitePermissionOverride { get; set; }
        /// <summary>
        /// Minimum Member Level allowed to update group culture
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        public bool updateCulturePermissionOverride { get; set; }
        /// <summary>
        /// Minimum Member Level allowed to host guided games
        /// Always Allowed: Founder, Acting Founder, Admin
        /// Allowed Overrides: None, Member, Beginner
        /// Default is Member for clans, None for groups, although this means nothing for groups.
        /// </summary>
        public Schema.GroupsV2.HostGuidedGamesPermissionLevel hostGuidedGamePermissionOverride { get; set; }
        /// <summary>
        /// Minimum Member Level allowed to update banner
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        public bool updateBannerPermissionOverride { get; set; }
        /// <summary>
        /// Level to join a member at when accepting an invite, application, or joining an open clan
        /// Default is Beginner.
        /// </summary>
        public Schema.GroupsV2.RuntimeGroupMemberType joinLevel { get; set; }
    }

    [System.Flags]
    public enum Capabilities
    {
        None = 0,
        Leaderboards = 1,
        Callsign = 2,
        OptionalConversations = 4,
        ClanBanner = 8,
        D2InvestmentData = 16,
        Tags = 32,
        Alliances = 64
    }

    /// <summary>
    /// Used for setting the guided game permission level override (admins and founders can always host guided games).
    /// </summary>
    public enum HostGuidedGamesPermissionLevel
    {
        None = 0,
        Beginner = 1,
        Member = 2
    }

    /// <summary>
    /// The member levels used by all V2 Groups API. Individual group types use their own mappings in their native storage (general uses BnetDbGroupMemberType and D2 clans use ClanMemberLevel), but they are all translated to this in the runtime api. These runtime values should NEVER be stored anywhere, so the values can be changed as necessary.
    /// </summary>
    public enum RuntimeGroupMemberType
    {
        None = 0,
        Beginner = 1,
        Member = 2,
        Admin = 3,
        ActingFounder = 4,
        Founder = 5
    }

    /// <summary>
    /// This contract contains clan-specific group information. It does not include any investment data.
    /// </summary>
    public class GroupV2ClanInfo
    {
        public string clanCallsign { get; set; }
        public Schema.GroupsV2.ClanBanner clanBannerData { get; set; }
    }

    public class ClanBanner
    {
        public uint decalId { get; set; }
        public uint decalColorId { get; set; }
        public uint decalBackgroundColorId { get; set; }
        public uint gonfalonId { get; set; }
        public uint gonfalonColorId { get; set; }
        public uint gonfalonDetailId { get; set; }
        public uint gonfalonDetailColorId { get; set; }
    }

    /// <summary>
    /// The same as GroupV2ClanInfo, but includes any investment data.
    /// </summary>
    public class GroupV2ClanInfoAndInvestment
    {
        public Dictionary<uint, Schema.Destiny.DestinyProgression> d2ClanProgressions { get; set; }
        public string clanCallsign { get; set; }
        public Schema.GroupsV2.ClanBanner clanBannerData { get; set; }
    }

    public class GroupUserBase
    {
        public long groupId { get; set; }
        public Schema.GroupsV2.GroupUserInfoCard destinyUserInfo { get; set; }
        public Schema.User.UserInfoCard bungieNetUserInfo { get; set; }
        public DateTime joinDate { get; set; }
    }

    public class GroupMember
    {
        public Schema.GroupsV2.RuntimeGroupMemberType memberType { get; set; }
        public bool isOnline { get; set; }
        public long lastOnlineStatusChange { get; set; }
        public long groupId { get; set; }
        public Schema.GroupsV2.GroupUserInfoCard destinyUserInfo { get; set; }
        public Schema.User.UserInfoCard bungieNetUserInfo { get; set; }
        public DateTime joinDate { get; set; }
    }

    public enum GroupAllianceStatus
    {
        Unallied = 0,
        Parent = 1,
        Child = 2
    }

    public class GroupPotentialMember
    {
        public Schema.GroupsV2.GroupPotentialMemberStatus potentialStatus { get; set; }
        public long groupId { get; set; }
        public Schema.GroupsV2.GroupUserInfoCard destinyUserInfo { get; set; }
        public Schema.User.UserInfoCard bungieNetUserInfo { get; set; }
        public DateTime joinDate { get; set; }
    }

    public enum GroupPotentialMemberStatus
    {
        None = 0,
        Applicant = 1,
        Invitee = 2
    }

    public enum GroupDateRange
    {
        All = 0,
        PastDay = 1,
        PastWeek = 2,
        PastMonth = 3,
        PastYear = 4
    }

    /// <summary>
    /// A small infocard of group information, usually used for when a list of groups are returned
    /// </summary>
    public class GroupV2Card
    {
        public long groupId { get; set; }
        public string name { get; set; }
        public Schema.GroupsV2.GroupType groupType { get; set; }
        public DateTime creationDate { get; set; }
        public string about { get; set; }
        public string motto { get; set; }
        public int memberCount { get; set; }
        public string locale { get; set; }
        public Schema.GroupsV2.MembershipOption membershipOption { get; set; }
        public Schema.GroupsV2.Capabilities capabilities { get; set; }
        public Schema.GroupsV2.GroupV2ClanInfo clanInfo { get; set; }
        public string avatarPath { get; set; }
        public string theme { get; set; }
    }

    public class GroupSearchResponse
    {
        public IEnumerable<Schema.GroupsV2.GroupV2Card> results { get; set; }
        public int totalResults { get; set; }
        public bool hasMore { get; set; }
        public Schema.Queries.PagedQuery query { get; set; }
        public string replacementContinuationToken { get; set; }
        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    /// <summary>
    /// NOTE: GroupQuery, as of Destiny 2, has essentially two totally different and incompatible "modes".
    /// If you are querying for a group, you can pass any of the properties below.
    /// If you are querying for a Clan, you MUST NOT pass any of the following properties (they must be null or undefined in your request, not just empty string/default values):
    /// - groupMemberCountFilter - localeFilter - tagText
    /// If you pass these, you will get a useless InvalidParameters error.
    /// </summary>
    public class GroupQuery
    {
        public string name { get; set; }
        public Schema.GroupsV2.GroupType groupType { get; set; }
        public Schema.GroupsV2.GroupDateRange creationDate { get; set; }
        public Schema.GroupsV2.GroupSortBy sortBy { get; set; }
        public int? groupMemberCountFilter { get; set; }
        public string localeFilter { get; set; }
        public string tagText { get; set; }
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
        public string requestContinuationToken { get; set; }
    }

    public enum GroupSortBy
    {
        Name = 0,
        Date = 1,
        Popularity = 2,
        Id = 3
    }

    public enum GroupMemberCountFilter
    {
        All = 0,
        OneToTen = 1,
        ElevenToOneHundred = 2,
        GreaterThanOneHundred = 3
    }

    public class GroupNameSearchRequest
    {
        public string groupName { get; set; }
        public Schema.GroupsV2.GroupType groupType { get; set; }
    }

    public class GroupOptionalConversation
    {
        public long groupId { get; set; }
        public long conversationId { get; set; }
        public bool chatEnabled { get; set; }
        public string chatName { get; set; }
        public Schema.GroupsV2.ChatSecuritySetting chatSecurity { get; set; }
    }

    public class GroupEditAction
    {
        public string name { get; set; }
        public string about { get; set; }
        public string motto { get; set; }
        public string theme { get; set; }
        public int? avatarImageIndex { get; set; }
        public string tags { get; set; }
        public bool? isPublic { get; set; }
        public int? membershipOption { get; set; }
        public bool? isPublicTopicAdminOnly { get; set; }
        public bool? allowChat { get; set; }
        public int? chatSecurity { get; set; }
        public string callsign { get; set; }
        public string locale { get; set; }
        public int? homepage { get; set; }
        public bool? enableInvitationMessagingForAdmins { get; set; }
        public int? defaultPublicity { get; set; }
    }

    public class GroupOptionsEditAction
    {
        /// <summary>
        /// Minimum Member Level allowed to invite new members to group
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        public bool? InvitePermissionOverride { get; set; }
        /// <summary>
        /// Minimum Member Level allowed to update group culture
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        public bool? UpdateCulturePermissionOverride { get; set; }
        /// <summary>
        /// Minimum Member Level allowed to host guided games
        /// Always Allowed: Founder, Acting Founder, Admin
        /// Allowed Overrides: None, Member, Beginner
        /// Default is Member for clans, None for groups, although this means nothing for groups.
        /// </summary>
        public int? HostGuidedGamePermissionOverride { get; set; }
        /// <summary>
        /// Minimum Member Level allowed to update banner
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        public bool? UpdateBannerPermissionOverride { get; set; }
        /// <summary>
        /// Level to join a member at when accepting an invite, application, or joining an open clan
        /// Default is Beginner.
        /// </summary>
        public int? JoinLevel { get; set; }
    }

    public class GroupOptionalConversationAddRequest
    {
        public string chatName { get; set; }
        public Schema.GroupsV2.ChatSecuritySetting chatSecurity { get; set; }
    }

    public class GroupOptionalConversationEditRequest
    {
        public bool? chatEnabled { get; set; }
        public string chatName { get; set; }
        public int? chatSecurity { get; set; }
    }

    public class GroupMemberLeaveResult
    {
        public Schema.GroupsV2.GroupV2 group { get; set; }
        public bool groupDeleted { get; set; }
    }

    public class GroupBanRequest
    {
        public string comment { get; set; }
        public Schema.Ignores.IgnoreLength length { get; set; }
    }

    public class GroupBan
    {
        public long groupId { get; set; }
        public Schema.User.UserInfoCard lastModifiedBy { get; set; }
        public Schema.User.UserInfoCard createdBy { get; set; }
        public DateTime dateBanned { get; set; }
        public DateTime dateExpires { get; set; }
        public string comment { get; set; }
        public Schema.User.UserInfoCard bungieNetUserInfo { get; set; }
        public Schema.GroupsV2.GroupUserInfoCard destinyUserInfo { get; set; }
    }

    public class GroupMemberApplication
    {
        public long groupId { get; set; }
        public DateTime creationDate { get; set; }
        public Schema.GroupsV2.GroupApplicationResolveState resolveState { get; set; }
        public DateTime? resolveDate { get; set; }
        public long? resolvedByMembershipId { get; set; }
        public string requestMessage { get; set; }
        public string resolveMessage { get; set; }
        public Schema.GroupsV2.GroupUserInfoCard destinyUserInfo { get; set; }
        public Schema.User.UserInfoCard bungieNetUserInfo { get; set; }
    }

    public enum GroupApplicationResolveState
    {
        Unresolved = 0,
        Accepted = 1,
        Denied = 2,
        Rescinded = 3
    }

    public class GroupApplicationRequest
    {
        public string message { get; set; }
    }

    public class GroupApplicationListRequest
    {
        public IEnumerable<Schema.User.UserMembership> memberships { get; set; }
        public string message { get; set; }
    }

    public enum GroupsForMemberFilter
    {
        All = 0,
        Founded = 1,
        NonFounded = 2
    }

    public class GroupMembershipBase
    {
        public Schema.GroupsV2.GroupV2 group { get; set; }
    }

    public class GroupMembership
    {
        public Schema.GroupsV2.GroupMember member { get; set; }
        public Schema.GroupsV2.GroupV2 group { get; set; }
    }

    public class GroupMembershipSearchResponse
    {
        public IEnumerable<Schema.GroupsV2.GroupMembership> results { get; set; }
        public int totalResults { get; set; }
        public bool hasMore { get; set; }
        public Schema.Queries.PagedQuery query { get; set; }
        public string replacementContinuationToken { get; set; }
        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class GetGroupsForMemberResponse
    {
        /// <summary>
        /// A convenience property that indicates if every membership this user has that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.
        ///  The key is the Group ID for the group being checked, and the value is true if the users' memberships for that group are all inactive.
        /// </summary>
        public Dictionary<long, bool> areAllMembershipsInactive { get; set; }
        public IEnumerable<Schema.GroupsV2.GroupMembership> results { get; set; }
        public int totalResults { get; set; }
        public bool hasMore { get; set; }
        public Schema.Queries.PagedQuery query { get; set; }
        public string replacementContinuationToken { get; set; }
        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class GroupPotentialMembership
    {
        public Schema.GroupsV2.GroupPotentialMember member { get; set; }
        public Schema.GroupsV2.GroupV2 group { get; set; }
    }

    public class GroupPotentialMembershipSearchResponse
    {
        public IEnumerable<Schema.GroupsV2.GroupPotentialMembership> results { get; set; }
        public int totalResults { get; set; }
        public bool hasMore { get; set; }
        public Schema.Queries.PagedQuery query { get; set; }
        public string replacementContinuationToken { get; set; }
        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class GroupApplicationResponse
    {
        public Schema.GroupsV2.GroupApplicationResolveState resolution { get; set; }
    }
}