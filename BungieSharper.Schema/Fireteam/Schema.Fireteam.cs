using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Fireteam
{
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
        Unknown = 0,

        Playstation4 = 1,

        XboxOne = 2,

        Blizzard = 3,

        Steam = 4,

        Stadia = 5
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
        public long fireteamId { get; set; }

        public long groupId { get; set; }

        public Fireteam.FireteamPlatform platform { get; set; }

        public int activityType { get; set; }

        public bool isImmediate { get; set; }

        public DateTime? scheduledTime { get; set; }

        public long ownerMembershipId { get; set; }

        public int playerSlotCount { get; set; }

        public int? alternateSlotCount { get; set; }

        public int availablePlayerSlotCount { get; set; }

        public int availableAlternateSlotCount { get; set; }

        public string title { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime? dateModified { get; set; }

        public bool isPublic { get; set; }

        public string locale { get; set; }

        public bool isValid { get; set; }

        public DateTime datePlayerModified { get; set; }

        public string titleBeforeModeration { get; set; }
    }

    public class FireteamResponse
    {
        public Fireteam.FireteamSummary Summary { get; set; }

        public IEnumerable<Fireteam.FireteamMember> Members { get; set; }

        public IEnumerable<Fireteam.FireteamMember> Alternates { get; set; }
    }

    public class FireteamMember
    {
        public Fireteam.FireteamUserInfoCard destinyUserInfo { get; set; }

        public User.UserInfoCard bungieNetUserInfo { get; set; }

        public long characterId { get; set; }

        public DateTime dateJoined { get; set; }

        public bool hasMicrophone { get; set; }

        public DateTime lastPlatformInviteAttemptDate { get; set; }

        public Fireteam.FireteamPlatformInviteResult lastPlatformInviteAttemptResult { get; set; }
    }

    public class FireteamUserInfoCard : User.UserInfoCard
    {
        public string FireteamDisplayName { get; set; }

        public BungieMembershipType FireteamMembershipType { get; set; }

        public string FireteamPlatformProfileUrl { get; set; }

        public string FireteamPlatformUniqueIdentifier { get; set; }
    }

    public enum FireteamPlatformInviteResult : byte
    {
        None = 0,

        Success = 1,

        AlreadyInFireteam = 2,

        Throttled = 3,

        ServiceError = 4
    }
}