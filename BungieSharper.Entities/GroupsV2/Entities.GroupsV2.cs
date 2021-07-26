using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.GroupsV2
{
    public class GroupUserInfoCard
    {
        /// <summary>This will be the display name the clan server last saw the user as. If the account is an active cross save override, this will be the display name to use. Otherwise, this will match the displayName property.</summary>
        [JsonPropertyName("LastSeenDisplayName")]
        public string LastSeenDisplayName { get; set; }

        /// <summary>The platform of the LastSeenDisplayName</summary>
        [JsonPropertyName("LastSeenDisplayNameType")]
        public BungieMembershipType LastSeenDisplayNameType { get; set; }

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
    }

    public class GroupResponse
    {
        [JsonPropertyName("detail")]
        public GroupV2 Detail { get; set; }

        [JsonPropertyName("founder")]
        public GroupMember Founder { get; set; }

        [JsonPropertyName("alliedIds")]
        public IEnumerable<long> AlliedIds { get; set; }

        [JsonPropertyName("parentGroup")]
        public GroupV2 ParentGroup { get; set; }

        [JsonPropertyName("allianceStatus")]
        public GroupAllianceStatus AllianceStatus { get; set; }

        [JsonPropertyName("groupJoinInviteCount")]
        public int GroupJoinInviteCount { get; set; }

        /// <summary>A convenience property that indicates if every membership you (the current user) have that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.</summary>
        [JsonPropertyName("currentUserMembershipsInactiveForDestiny")]
        public bool CurrentUserMembershipsInactiveForDestiny { get; set; }

        /// <summary>This property will be populated if the authenticated user is a member of the group. Note that because of account linking, a user can sometimes be part of a clan more than once. As such, this returns the highest member type available.</summary>
        [JsonPropertyName("currentUserMemberMap")]
        public Dictionary<BungieMembershipType, GroupsV2.GroupMember> CurrentUserMemberMap { get; set; }

        /// <summary>This property will be populated if the authenticated user is an applicant or has an outstanding invitation to join. Note that because of account linking, a user can sometimes be part of a clan more than once.</summary>
        [JsonPropertyName("currentUserPotentialMemberMap")]
        public Dictionary<BungieMembershipType, GroupsV2.GroupPotentialMember> CurrentUserPotentialMemberMap { get; set; }
    }

    public class GroupV2
    {
        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; set; }

        [JsonPropertyName("membershipIdCreated")]
        public long MembershipIdCreated { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("modificationDate")]
        public DateTime ModificationDate { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; set; }

        [JsonPropertyName("memberCount")]
        public int MemberCount { get; set; }

        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; }

        [JsonPropertyName("isPublicTopicAdminOnly")]
        public bool IsPublicTopicAdminOnly { get; set; }

        [JsonPropertyName("motto")]
        public string Motto { get; set; }

        [JsonPropertyName("allowChat")]
        public bool AllowChat { get; set; }

        [JsonPropertyName("isDefaultPostPublic")]
        public bool IsDefaultPostPublic { get; set; }

        [JsonPropertyName("chatSecurity")]
        public ChatSecuritySetting ChatSecurity { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("avatarImageIndex")]
        public int AvatarImageIndex { get; set; }

        [JsonPropertyName("homepage")]
        public GroupHomepage Homepage { get; set; }

        [JsonPropertyName("membershipOption")]
        public MembershipOption MembershipOption { get; set; }

        [JsonPropertyName("defaultPublicity")]
        public GroupPostPublicity DefaultPublicity { get; set; }

        [JsonPropertyName("theme")]
        public string Theme { get; set; }

        [JsonPropertyName("bannerPath")]
        public string BannerPath { get; set; }

        [JsonPropertyName("avatarPath")]
        public string AvatarPath { get; set; }

        [JsonPropertyName("conversationId")]
        public long ConversationId { get; set; }

        [JsonPropertyName("enableInvitationMessagingForAdmins")]
        public bool EnableInvitationMessagingForAdmins { get; set; }

        [JsonPropertyName("banExpireDate"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? BanExpireDate { get; set; }

        [JsonPropertyName("features")]
        public GroupFeatures Features { get; set; }

        [JsonPropertyName("clanInfo")]
        public GroupV2ClanInfoAndInvestment ClanInfo { get; set; }
    }

    public enum GroupType : int
    {
        General = 0,
        Clan = 1
    }

    public enum ChatSecuritySetting : int
    {
        Group = 0,
        Admins = 1
    }

    public enum GroupHomepage : int
    {
        Wall = 0,
        Forum = 1,
        AllianceForum = 2
    }

    public enum MembershipOption : int
    {
        Reviewed = 0,
        Open = 1,
        Closed = 2
    }

    public enum GroupPostPublicity : int
    {
        Public = 0,
        Alliance = 1,
        Private = 2
    }

    public class GroupFeatures
    {
        [JsonPropertyName("maximumMembers")]
        public int MaximumMembers { get; set; }

        /// <summary>Maximum number of groups of this type a typical membership may join. For example, a user may join about 50 General groups with their Bungie.net account. They may join one clan per Destiny membership.</summary>
        [JsonPropertyName("maximumMembershipsOfGroupType")]
        public int MaximumMembershipsOfGroupType { get; set; }

        [JsonPropertyName("capabilities")]
        public Capabilities Capabilities { get; set; }

        [JsonPropertyName("membershipTypes")]
        public IEnumerable<BungieMembershipType> MembershipTypes { get; set; }

        /// <summary>
        /// Minimum Member Level allowed to invite new members to group
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        [JsonPropertyName("invitePermissionOverride")]
        public bool InvitePermissionOverride { get; set; }

        /// <summary>
        /// Minimum Member Level allowed to update group culture
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        [JsonPropertyName("updateCulturePermissionOverride")]
        public bool UpdateCulturePermissionOverride { get; set; }

        /// <summary>
        /// Minimum Member Level allowed to host guided games
        /// Always Allowed: Founder, Acting Founder, Admin
        /// Allowed Overrides: None, Member, Beginner
        /// Default is Member for clans, None for groups, although this means nothing for groups.
        /// </summary>
        [JsonPropertyName("hostGuidedGamePermissionOverride")]
        public HostGuidedGamesPermissionLevel HostGuidedGamePermissionOverride { get; set; }

        /// <summary>
        /// Minimum Member Level allowed to update banner
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        [JsonPropertyName("updateBannerPermissionOverride")]
        public bool UpdateBannerPermissionOverride { get; set; }

        /// <summary>
        /// Level to join a member at when accepting an invite, application, or joining an open clan
        /// Default is Beginner.
        /// </summary>
        [JsonPropertyName("joinLevel")]
        public RuntimeGroupMemberType JoinLevel { get; set; }
    }

    [Flags]
    public enum Capabilities : int
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
    public enum HostGuidedGamesPermissionLevel : int
    {
        None = 0,
        Beginner = 1,
        Member = 2
    }

    /// <summary>
    /// The member levels used by all V2 Groups API. Individual group types use their own mappings in their native storage (general uses BnetDbGroupMemberType and D2 clans use ClanMemberLevel), but they are all translated to this in the runtime api. These runtime values should NEVER be stored anywhere, so the values can be changed as necessary.
    /// </summary>
    public enum RuntimeGroupMemberType : int
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
        [JsonPropertyName("clanCallsign")]
        public string ClanCallsign { get; set; }

        [JsonPropertyName("clanBannerData")]
        public ClanBanner ClanBannerData { get; set; }
    }

    public class ClanBanner
    {
        [JsonPropertyName("decalId")]
        public uint DecalId { get; set; }

        [JsonPropertyName("decalColorId")]
        public uint DecalColorId { get; set; }

        [JsonPropertyName("decalBackgroundColorId")]
        public uint DecalBackgroundColorId { get; set; }

        [JsonPropertyName("gonfalonId")]
        public uint GonfalonId { get; set; }

        [JsonPropertyName("gonfalonColorId")]
        public uint GonfalonColorId { get; set; }

        [JsonPropertyName("gonfalonDetailId")]
        public uint GonfalonDetailId { get; set; }

        [JsonPropertyName("gonfalonDetailColorId")]
        public uint GonfalonDetailColorId { get; set; }
    }

    /// <summary>
    /// The same as GroupV2ClanInfo, but includes any investment data.
    /// </summary>
    public class GroupV2ClanInfoAndInvestment
    {
        [JsonPropertyName("d2ClanProgressions")]
        public Dictionary<uint, Destiny.DestinyProgression> D2ClanProgressions { get; set; }

        [JsonPropertyName("clanCallsign")]
        public string ClanCallsign { get; set; }

        [JsonPropertyName("clanBannerData")]
        public ClanBanner ClanBannerData { get; set; }
    }

    public class GroupUserBase
    {
        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("destinyUserInfo")]
        public GroupUserInfoCard DestinyUserInfo { get; set; }

        [JsonPropertyName("bungieNetUserInfo")]
        public User.UserInfoCard BungieNetUserInfo { get; set; }

        [JsonPropertyName("joinDate")]
        public DateTime JoinDate { get; set; }
    }

    public class GroupMember
    {
        [JsonPropertyName("memberType")]
        public RuntimeGroupMemberType MemberType { get; set; }

        [JsonPropertyName("isOnline")]
        public bool IsOnline { get; set; }

        [JsonPropertyName("lastOnlineStatusChange")]
        public long LastOnlineStatusChange { get; set; }

        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("destinyUserInfo")]
        public GroupUserInfoCard DestinyUserInfo { get; set; }

        [JsonPropertyName("bungieNetUserInfo")]
        public User.UserInfoCard BungieNetUserInfo { get; set; }

        [JsonPropertyName("joinDate")]
        public DateTime JoinDate { get; set; }
    }

    public enum GroupAllianceStatus : int
    {
        Unallied = 0,
        Parent = 1,
        Child = 2
    }

    public class GroupPotentialMember
    {
        [JsonPropertyName("potentialStatus")]
        public GroupPotentialMemberStatus PotentialStatus { get; set; }

        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("destinyUserInfo")]
        public GroupUserInfoCard DestinyUserInfo { get; set; }

        [JsonPropertyName("bungieNetUserInfo")]
        public User.UserInfoCard BungieNetUserInfo { get; set; }

        [JsonPropertyName("joinDate")]
        public DateTime JoinDate { get; set; }
    }

    public enum GroupPotentialMemberStatus : int
    {
        None = 0,
        Applicant = 1,
        Invitee = 2
    }

    public enum GroupDateRange : int
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
        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("motto")]
        public string Motto { get; set; }

        [JsonPropertyName("memberCount")]
        public int MemberCount { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("membershipOption")]
        public MembershipOption MembershipOption { get; set; }

        [JsonPropertyName("capabilities")]
        public Capabilities Capabilities { get; set; }

        [JsonPropertyName("clanInfo")]
        public GroupV2ClanInfo ClanInfo { get; set; }

        [JsonPropertyName("avatarPath")]
        public string AvatarPath { get; set; }

        [JsonPropertyName("theme")]
        public string Theme { get; set; }
    }

    public class GroupSearchResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupV2Card> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
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
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; set; }

        [JsonPropertyName("creationDate")]
        public GroupDateRange CreationDate { get; set; }

        [JsonPropertyName("sortBy")]
        public GroupSortBy SortBy { get; set; }

        [JsonPropertyName("groupMemberCountFilter"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? GroupMemberCountFilter { get; set; }

        [JsonPropertyName("localeFilter")]
        public string LocaleFilter { get; set; }

        [JsonPropertyName("tagText")]
        public string TagText { get; set; }

        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("requestContinuationToken")]
        public string RequestContinuationToken { get; set; }
    }

    public enum GroupSortBy : int
    {
        Name = 0,
        Date = 1,
        Popularity = 2,
        Id = 3
    }

    public enum GroupMemberCountFilter : int
    {
        All = 0,
        OneToTen = 1,
        ElevenToOneHundred = 2,
        GreaterThanOneHundred = 3
    }

    public class GroupNameSearchRequest
    {
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }

        [JsonPropertyName("groupType")]
        public GroupType GroupType { get; set; }
    }

    public class GroupOptionalConversation
    {
        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("conversationId")]
        public long ConversationId { get; set; }

        [JsonPropertyName("chatEnabled")]
        public bool ChatEnabled { get; set; }

        [JsonPropertyName("chatName")]
        public string ChatName { get; set; }

        [JsonPropertyName("chatSecurity")]
        public ChatSecuritySetting ChatSecurity { get; set; }
    }

    public class GroupEditAction
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("motto")]
        public string Motto { get; set; }

        [JsonPropertyName("theme")]
        public string Theme { get; set; }

        [JsonPropertyName("avatarImageIndex"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AvatarImageIndex { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonPropertyName("isPublic"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsPublic { get; set; }

        [JsonPropertyName("membershipOption"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MembershipOption { get; set; }

        [JsonPropertyName("isPublicTopicAdminOnly"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsPublicTopicAdminOnly { get; set; }

        [JsonPropertyName("allowChat"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowChat { get; set; }

        [JsonPropertyName("chatSecurity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ChatSecurity { get; set; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("homepage"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Homepage { get; set; }

        [JsonPropertyName("enableInvitationMessagingForAdmins"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnableInvitationMessagingForAdmins { get; set; }

        [JsonPropertyName("defaultPublicity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DefaultPublicity { get; set; }
    }

    public class GroupOptionsEditAction
    {
        /// <summary>
        /// Minimum Member Level allowed to invite new members to group
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        [JsonPropertyName("InvitePermissionOverride"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? InvitePermissionOverride { get; set; }

        /// <summary>
        /// Minimum Member Level allowed to update group culture
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        [JsonPropertyName("UpdateCulturePermissionOverride"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UpdateCulturePermissionOverride { get; set; }

        /// <summary>
        /// Minimum Member Level allowed to host guided games
        /// Always Allowed: Founder, Acting Founder, Admin
        /// Allowed Overrides: None, Member, Beginner
        /// Default is Member for clans, None for groups, although this means nothing for groups.
        /// </summary>
        [JsonPropertyName("HostGuidedGamePermissionOverride"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? HostGuidedGamePermissionOverride { get; set; }

        /// <summary>
        /// Minimum Member Level allowed to update banner
        /// Always Allowed: Founder, Acting Founder
        /// True means admins have this power, false means they don't
        /// Default is false for clans, true for groups.
        /// </summary>
        [JsonPropertyName("UpdateBannerPermissionOverride"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UpdateBannerPermissionOverride { get; set; }

        /// <summary>
        /// Level to join a member at when accepting an invite, application, or joining an open clan
        /// Default is Beginner.
        /// </summary>
        [JsonPropertyName("JoinLevel"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? JoinLevel { get; set; }
    }

    public class GroupOptionalConversationAddRequest
    {
        [JsonPropertyName("chatName")]
        public string ChatName { get; set; }

        [JsonPropertyName("chatSecurity")]
        public ChatSecuritySetting ChatSecurity { get; set; }
    }

    public class GroupOptionalConversationEditRequest
    {
        [JsonPropertyName("chatEnabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ChatEnabled { get; set; }

        [JsonPropertyName("chatName")]
        public string ChatName { get; set; }

        [JsonPropertyName("chatSecurity"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ChatSecurity { get; set; }
    }

    public class GroupMemberLeaveResult
    {
        [JsonPropertyName("group")]
        public GroupV2 Group { get; set; }

        [JsonPropertyName("groupDeleted")]
        public bool GroupDeleted { get; set; }
    }

    public class GroupBanRequest
    {
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("length")]
        public Ignores.IgnoreLength Length { get; set; }
    }

    public class GroupBan
    {
        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("lastModifiedBy")]
        public User.UserInfoCard LastModifiedBy { get; set; }

        [JsonPropertyName("createdBy")]
        public User.UserInfoCard CreatedBy { get; set; }

        [JsonPropertyName("dateBanned")]
        public DateTime DateBanned { get; set; }

        [JsonPropertyName("dateExpires")]
        public DateTime DateExpires { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("bungieNetUserInfo")]
        public User.UserInfoCard BungieNetUserInfo { get; set; }

        [JsonPropertyName("destinyUserInfo")]
        public GroupUserInfoCard DestinyUserInfo { get; set; }
    }

    public class GroupMemberApplication
    {
        [JsonPropertyName("groupId")]
        public long GroupId { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("resolveState")]
        public GroupApplicationResolveState ResolveState { get; set; }

        [JsonPropertyName("resolveDate"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ResolveDate { get; set; }

        [JsonPropertyName("resolvedByMembershipId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ResolvedByMembershipId { get; set; }

        [JsonPropertyName("requestMessage")]
        public string RequestMessage { get; set; }

        [JsonPropertyName("resolveMessage")]
        public string ResolveMessage { get; set; }

        [JsonPropertyName("destinyUserInfo")]
        public GroupUserInfoCard DestinyUserInfo { get; set; }

        [JsonPropertyName("bungieNetUserInfo")]
        public User.UserInfoCard BungieNetUserInfo { get; set; }
    }

    public enum GroupApplicationResolveState : int
    {
        Unresolved = 0,
        Accepted = 1,
        Denied = 2,
        Rescinded = 3
    }

    public class GroupApplicationRequest
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class GroupApplicationListRequest
    {
        [JsonPropertyName("memberships")]
        public IEnumerable<User.UserMembership> Memberships { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public enum GroupsForMemberFilter : int
    {
        All = 0,
        Founded = 1,
        NonFounded = 2
    }

    public class GroupMembershipBase
    {
        [JsonPropertyName("group")]
        public GroupV2 Group { get; set; }
    }

    public class GroupMembership
    {
        [JsonPropertyName("member")]
        public GroupMember Member { get; set; }

        [JsonPropertyName("group")]
        public GroupV2 Group { get; set; }
    }

    public class GroupMembershipSearchResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupMembership> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

    public class GetGroupsForMemberResponse
    {
        /// <summary>
        /// A convenience property that indicates if every membership this user has that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.
        /// The key is the Group ID for the group being checked, and the value is true if the users' memberships for that group are all inactive.
        /// </summary>
        [JsonPropertyName("areAllMembershipsInactive")]
        public Dictionary<long, bool> AreAllMembershipsInactive { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupMembership> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

    public class GroupPotentialMembership
    {
        [JsonPropertyName("member")]
        public GroupPotentialMember Member { get; set; }

        [JsonPropertyName("group")]
        public GroupV2 Group { get; set; }
    }

    public class GroupPotentialMembershipSearchResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<GroupsV2.GroupPotentialMembership> Results { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        [JsonPropertyName("query")]
        public Queries.PagedQuery Query { get; set; }

        [JsonPropertyName("replacementContinuationToken")]
        public string ReplacementContinuationToken { get; set; }

        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        [JsonPropertyName("useTotalResults")]
        public bool UseTotalResults { get; set; }
    }

    public class GroupApplicationResponse
    {
        [JsonPropertyName("resolution")]
        public GroupApplicationResolveState Resolution { get; set; }
    }
}