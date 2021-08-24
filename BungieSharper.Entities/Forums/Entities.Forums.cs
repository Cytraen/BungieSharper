using System;

namespace BungieSharper.Entities.Forums
{
    [Flags]
    public enum ForumPostCategoryEnums : int
    {
        None = 0,
        TextOnly = 1,
        Media = 2,
        Link = 4,
        Poll = 8,
        Question = 16,
        Answered = 32,
        Announcement = 64,
        ContentComment = 128,
        BungieOfficial = 256,
        NinjaOfficial = 512,
        Recruitment = 1024
    }

    [Flags]
    public enum ForumFlagsEnum : int
    {
        None = 0,
        BungieStaffPost = 1,
        ForumNinjaPost = 2,
        ForumMentorPost = 4,
        TopicBungieStaffPosted = 8,
        TopicBungieVolunteerPosted = 16,
        QuestionAnsweredByBungie = 32,
        QuestionAnsweredByNinja = 64,
        CommunityContent = 128
    }
}