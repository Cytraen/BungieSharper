using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Definitions.Milestones
{
    /// <summary>
    /// Milestones are an in-game concept where they're attempting to tell you what you can do next in-game.
    /// If that sounds a lot like Advisors in Destiny 1, it is! So we threw out Advisors in the Destiny 2 API and tacked all of the data we would have put on Advisors onto Milestones instead.
    /// Each Milestone represents something going on in the game right now:
    /// - A "ritual activity" you can perform, like nightfall
    /// - A "special event" that may have activities related to it, like Taco Tuesday (there's no Taco Tuesday in Destiny 2)
    /// - A checklist you can fulfill, like helping your Clan complete all of its weekly objectives
    /// - A tutorial quest you can play through, like the introduction to the Crucible.
    /// Most of these milestones appear in game as well. Some of them are BNet only, because we're so extra. You're welcome.
    /// There are some important caveats to understand about how we currently render Milestones and their deficiencies. The game currently doesn't have any content that actually tells you oughtright *what* the Milestone is: that is to say, what you'll be doing. The best we get is either a description of the overall Milestone, or of the Quest that the Milestone is having you partake in: which is usually something that assumes you already know what it's talking about, like "Complete 5 Challenges". 5 Challenges for what? What's a challenge? These are not questions that the Milestone data will answer for you unfortunately.
    /// This isn't great, and in the future I'd like to add some custom text to give you more contextual information to pass on to your users. But for now, you can do what we do to render what little display info we do have:
    /// Start by looking at the currently active quest (ideally, you've fetched DestinyMilestone or DestinyPublicMilestone data from the API, so you know the currently active quest for the Milestone in question). Look up the Quests property in the Milestone Definition, and check if it has display properties. If it does, show that as the description of the Milestone. If it doesn't, fall back on the Milestone's description.
    /// This approach will let you avoid, whenever possible, the even less useful (and sometimes nonexistant) milestone-level names and descriptions.
    /// </summary>
    public class DestinyMilestoneDefinition
    {
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>A hint to the UI to indicate what to show as the display properties for this Milestone when showing "Live" milestone data. Feel free to show more than this if desired: this hint is meant to simplify our own UI, but it may prove useful to you as well.</summary>
        [JsonPropertyName("displayPreference")]
        public DestinyMilestoneDisplayPreference DisplayPreference { get; set; }

        /// <summary>A custom image someone made just for the milestone. Isn't that special?</summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>An enumeration listing one of the possible types of milestones. Check out the DestinyMilestoneType enum for more info!</summary>
        [JsonPropertyName("milestoneType")]
        public DestinyMilestoneType MilestoneType { get; set; }

        /// <summary>If True, then the Milestone has been integrated with BNet's recruiting feature.</summary>
        [JsonPropertyName("recruitable")]
        public bool Recruitable { get; set; }

        /// <summary>If the milestone has a friendly identifier for association with other features - such as Recruiting - that identifier can be found here. This is "friendly" in that it looks better in a URL than whatever the identifier for the Milestone actually is.</summary>
        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>If TRUE, this entry should be returned in the list of milestones for the "Explore Destiny" (i.e. new BNet homepage) features of Bungie.net (as long as the underlying event is active) Note that this is a property specifically used by BNet and the companion app for the "Live Events" feature of the front page/welcome view: it's not a reflection of what you see in-game.</summary>
        [JsonPropertyName("showInExplorer")]
        public bool ShowInExplorer { get; set; }

        /// <summary>Determines whether we'll show this Milestone in the user's personal Milestones list.</summary>
        [JsonPropertyName("showInMilestones")]
        public bool ShowInMilestones { get; set; }

        /// <summary>If TRUE, "Explore Destiny" (the front page of BNet and the companion app) prioritize using the activity image over any overriding Quest or Milestone image provided. This unfortunate hack is brought to you by Trials of The Nine.</summary>
        [JsonPropertyName("explorePrioritizesActivityImage")]
        public bool ExplorePrioritizesActivityImage { get; set; }

        /// <summary>A shortcut for clients - and the server - to understand whether we can predict the start and end dates for this event. In practice, there are multiple ways that an event could have predictable date ranges, but not all events will be able to be predicted via any mechanism (for instance, events that are manually triggered on and off)</summary>
        [JsonPropertyName("hasPredictableDates")]
        public bool HasPredictableDates { get; set; }

        /// <summary>
        /// The full set of possible Quests that give the overview of the Milestone event/activity in question. Only one of these can be active at a time for a given Conceptual Milestone, but many of them may be "available" for the user to choose from. (for instance, with Milestones you can choose from the three available Quests, but only one can be active at a time) Keyed by the quest item.
        /// As of Forsaken (~September 2018), Quest-style Milestones are being removed for many types of activities. There will likely be further revisions to the Milestone concept in the future.
        /// </summary>
        [JsonPropertyName("quests")]
        public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneQuestDefinition> Quests { get; set; }

        /// <summary>
        /// If this milestone can provide rewards, this will define the categories into which the individual reward entries are placed.
        /// This is keyed by the Category's hash, which is only guaranteed to be unique within a given Milestone.
        /// </summary>
        [JsonPropertyName("rewards")]
        public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneRewardCategoryDefinition> Rewards { get; set; }

        /// <summary>If you're going to show Vendors for the Milestone, you can use this as a localized "header" for the section where you show that vendor data. It'll provide a more context-relevant clue about what the vendor's role is in the Milestone.</summary>
        [JsonPropertyName("vendorsDisplayTitle")]
        public string VendorsDisplayTitle { get; set; }

        /// <summary>Sometimes, milestones will have rewards provided by Vendors. This definition gives the information needed to understand which vendors are relevant, the order in which they should be returned if order matters, and the conditions under which the Vendor is relevant to the user.</summary>
        [JsonPropertyName("vendors")]
        public IEnumerable<Destiny.Definitions.Milestones.DestinyMilestoneVendorDefinition> Vendors { get; set; }

        /// <summary>Sometimes, milestones will have arbitrary values associated with them that are of interest to us or to third party developers. This is the collection of those values' definitions, keyed by the identifier of the value and providing useful definition information such as localizable names and descriptions for the value.</summary>
        [JsonPropertyName("values")]
        public Dictionary<string, Destiny.Definitions.Milestones.DestinyMilestoneValueDefinition> Values { get; set; }

        /// <summary>Some milestones are explicit objectives that you can see and interact with in the game. Some milestones are more conceptual, built by BNet to help advise you on activities and events that happen in-game but that aren't explicitly shown in game as Milestones. If this is TRUE, you can see this as a milestone in the game. If this is FALSE, it's an event or activity you can participate in, but you won't see it as a Milestone in the game's UI.</summary>
        [JsonPropertyName("isInGameMilestone")]
        public bool IsInGameMilestone { get; set; }

        /// <summary>A Milestone can now be represented by one or more activities directly (without a backing Quest), and that activity can have many challenges, modifiers, and related to it.</summary>
        [JsonPropertyName("activities")]
        public IEnumerable<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityDefinition> Activities { get; set; }

        [JsonPropertyName("defaultOrder")]
        public int DefaultOrder { get; set; }

        /// <summary>
        /// The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
        /// When entities refer to each other in Destiny content, it is this hash that they are referring to.
        /// </summary>
        [JsonPropertyName("hash")]
        public uint Hash { get; set; }

        /// <summary>The index of the entity as it was found in the investment tables.</summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!</summary>
        [JsonPropertyName("redacted")]
        public bool Redacted { get; set; }
    }

    /// <summary>
    /// A hint for the UI as to what display information ought to be shown. Defaults to showing the static MilestoneDefinition's display properties.
    /// If for some reason the indicated property is not populated, fall back to the MilestoneDefinition.displayProperties.
    /// </summary>
    public enum DestinyMilestoneDisplayPreference : int
    {
        /// <summary>Indicates you should show DestinyMilestoneDefinition.displayProperties for this Milestone.</summary>
        MilestoneDefinition = 0,

        /// <summary>Indicates you should show the displayProperties for any currently active Quest Steps in DestinyMilestone.availableQuests.</summary>
        CurrentQuestSteps = 1,

        /// <summary>Indicates you should show the displayProperties for any currently active Activities and their Challenges in DestinyMilestone.activities.</summary>
        CurrentActivityChallenges = 2
    }

    /// <summary>
    /// The type of milestone. Milestones can be Tutorials, one-time/triggered/non-repeating but not necessarily tutorials, or Repeating Milestones.
    /// </summary>
    public enum DestinyMilestoneType : int
    {
        Unknown = 0,

        /// <summary>One-time milestones that are specifically oriented toward teaching players about new mechanics and gameplay modes.</summary>
        Tutorial = 1,

        /// <summary>Milestones that, once completed a single time, can never be repeated.</summary>
        OneTime = 2,

        /// <summary>Milestones that repeat/reset on a weekly basis. They need not all reset on the same day or time, but do need to reset weekly to qualify for this type.</summary>
        Weekly = 3,

        /// <summary>Milestones that repeat or reset on a daily basis.</summary>
        Daily = 4,

        /// <summary>Special indicates that the event is not on a daily/weekly cadence, but does occur more than once. For instance, Iron Banner in Destiny 1 or the Dawning were examples of what could be termed "Special" events.</summary>
        Special = 5
    }

    /// <summary>
    /// Any data we need to figure out whether this Quest Item is the currently active one for the conceptual Milestone. Even just typing this description, I already regret it.
    /// </summary>
    public class DestinyMilestoneQuestDefinition
    {
        /// <summary>The item representing this Milestone quest. Use this hash to look up the DestinyInventoryItemDefinition for the quest to find its steps and human readable data.</summary>
        [JsonPropertyName("questItemHash")]
        public uint QuestItemHash { get; set; }

        /// <summary>The individual quests may have different definitions from the overall milestone: if there's a specific active quest, use these displayProperties instead of that of the overall DestinyMilestoneDefinition.</summary>
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>If populated, this image can be shown instead of the generic milestone's image when this quest is live, or it can be used to show a background image for the quest itself that differs from that of the Activity or the Milestone.</summary>
        [JsonPropertyName("overrideImage")]
        public string OverrideImage { get; set; }

        /// <summary>The rewards you will get for completing this quest, as best as we could extract them from our data. Sometimes, it'll be a decent amount of data. Sometimes, it's going to be sucky. Sorry.</summary>
        [JsonPropertyName("questRewards")]
        public DestinyMilestoneQuestRewardsDefinition QuestRewards { get; set; }

        /// <summary>The full set of all possible "conceptual activities" that are related to this Milestone. Tiers or alternative modes of play within these conceptual activities will be defined as sub-entities. Keyed by the Conceptual Activity Hash. Use the key to look up DestinyActivityDefinition.</summary>
        [JsonPropertyName("activities")]
        public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneActivityDefinition> Activities { get; set; }

        /// <summary>Sometimes, a Milestone's quest is related to an entire Destination rather than a specific activity. In that situation, this will be the hash of that Destination. Hotspots are currently the only Milestones that expose this data, but that does not preclude this data from being returned for other Milestones in the future.</summary>
        [JsonPropertyName("destinationHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? DestinationHash { get; set; }
    }

    /// <summary>
    /// If rewards are given in a quest - as opposed to overall in the entire Milestone - there's way less to track. We're going to simplify this contract as a result. However, this also gives us the opportunity to potentially put more than just item information into the reward data if we're able to mine it out in the future. Remember this if you come back and ask "why are quest reward items nested inside of their own class?"
    /// </summary>
    public class DestinyMilestoneQuestRewardsDefinition
    {
        /// <summary>
        /// The items that represent your reward for completing the quest.
        /// Be warned, these could be "dummy" items: items that are only used to render a good-looking in-game tooltip, but aren't the actual items themselves.
        /// For instance, when experience is given there's often a dummy item representing "experience", with quantity being the amount of experience you got. We don't have a programmatic association between those and whatever Progression is actually getting that experience... yet.
        /// </summary>
        [JsonPropertyName("items")]
        public IEnumerable<Destiny.Definitions.Milestones.DestinyMilestoneQuestRewardItem> Items { get; set; }
    }

    /// <summary>
    /// A subclass of DestinyItemQuantity, that provides not just the item and its quantity but also information that BNet can - at some point - use internally to provide more robust runtime information about the item's qualities.
    /// If you want it, please ask! We're just out of time to wire it up right now. Or a clever person just may do it with our existing endpoints.
    /// </summary>
    public class DestinyMilestoneQuestRewardItem
    {
        /// <summary>The quest reward item *may* be associated with a vendor. If so, this is that vendor. Use this hash to look up the DestinyVendorDefinition.</summary>
        [JsonPropertyName("vendorHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? VendorHash { get; set; }

        /// <summary>The quest reward item *may* be associated with a vendor. If so, this is the index of the item being sold, which we can use at runtime to find instanced item information for the reward item.</summary>
        [JsonPropertyName("vendorItemIndex"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? VendorItemIndex { get; set; }

        /// <summary>The hash identifier for the item in question. Use it to look up the item's DestinyInventoryItemDefinition.</summary>
        [JsonPropertyName("itemHash")]
        public uint ItemHash { get; set; }

        /// <summary>If this quantity is referring to a specific instance of an item, this will have the item's instance ID. Normally, this will be null.</summary>
        [JsonPropertyName("itemInstanceId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? ItemInstanceId { get; set; }

        /// <summary>The amount of the item needed/available depending on the context of where DestinyItemQuantity is being used.</summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>Indicates that this item quantity may be conditionally shown or hidden, based on various sources of state. For example: server flags, account state, or character progress.</summary>
        [JsonPropertyName("hasConditionalVisibility")]
        public bool HasConditionalVisibility { get; set; }
    }

    /// <summary>
    /// Milestones can have associated activities which provide additional information about the context, challenges, modifiers, state etc... related to this Milestone.
    /// Information we need to be able to return that data is defined here, along with Tier data to establish a relationship between a conceptual Activity and its difficulty levels and variants.
    /// </summary>
    public class DestinyMilestoneActivityDefinition
    {
        /// <summary>
        /// The "Conceptual" activity hash. Basically, we picked the lowest level activity and are treating it as the canonical definition of the activity for rendering purposes.
        /// If you care about the specific difficulty modes and variations, use the activities under "Variants".
        /// </summary>
        [JsonPropertyName("conceptualActivityHash")]
        public uint ConceptualActivityHash { get; set; }

        /// <summary>
        /// A milestone-referenced activity can have many variants, such as Tiers or alternative modes of play.
        /// Even if there is only a single variant, the details for these are represented within as a variant definition.
        /// It is assumed that, if this DestinyMilestoneActivityDefinition is active, then all variants should be active.
        /// If a Milestone could ever split the variants' active status conditionally, they should all have their own DestinyMilestoneActivityDefinition instead! The potential duplication will be worth it for the obviousness of processing and use.
        /// </summary>
        [JsonPropertyName("variants")]
        public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneActivityVariantDefinition> Variants { get; set; }
    }

    /// <summary>
    /// Represents a variant on an activity for a Milestone: a specific difficulty tier, or a specific activity variant for example.
    /// These will often have more specific details, such as an associated Guided Game, progression steps, tier-specific rewards, and custom values.
    /// </summary>
    public class DestinyMilestoneActivityVariantDefinition
    {
        /// <summary>
        /// The hash to use for looking up the variant Activity's definition (DestinyActivityDefinition), where you can find its distinguishing characteristics such as difficulty level and recommended light level.
        /// Frequently, that will be the only distinguishing characteristics in practice, which is somewhat of a bummer.
        /// </summary>
        [JsonPropertyName("activityHash")]
        public uint ActivityHash { get; set; }

        /// <summary>
        /// If you care to do so, render the variants in the order prescribed by this value.
        /// When you combine live Milestone data with the definition, the order becomes more useful because you'll be cross-referencing between the definition and live data.
        /// </summary>
        [JsonPropertyName("order")]
        public int Order { get; set; }
    }

    /// <summary>
    /// The definition of a category of rewards, that contains many individual rewards.
    /// </summary>
    public class DestinyMilestoneRewardCategoryDefinition
    {
        /// <summary>Identifies the reward category. Only guaranteed unique within this specific component!</summary>
        [JsonPropertyName("categoryHash")]
        public uint CategoryHash { get; set; }

        /// <summary>The string identifier for the category, if you want to use it for some end. Guaranteed unique within the specific component.</summary>
        [JsonPropertyName("categoryIdentifier")]
        public string CategoryIdentifier { get; set; }

        /// <summary>Hopefully this is obvious by now.</summary>
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>If this milestone can provide rewards, this will define the sets of rewards that can be earned, the conditions under which they can be acquired, internal data that we'll use at runtime to determine whether you've already earned or redeemed this set of rewards, and the category that this reward should be placed under.</summary>
        [JsonPropertyName("rewardEntries")]
        public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneRewardEntryDefinition> RewardEntries { get; set; }

        /// <summary>If you want to use BNet's recommended order for rendering categories programmatically, use this value and compare it to other categories to determine the order in which they should be rendered. I don't feel great about putting this here, I won't lie.</summary>
        [JsonPropertyName("order")]
        public int Order { get; set; }
    }

    /// <summary>
    /// The definition of a specific reward, which may be contained in a category of rewards and that has optional information about how it is obtained.
    /// </summary>
    public class DestinyMilestoneRewardEntryDefinition
    {
        /// <summary>The identifier for this reward entry. Runtime data will refer to reward entries by this hash. Only guaranteed unique within the specific Milestone.</summary>
        [JsonPropertyName("rewardEntryHash")]
        public uint RewardEntryHash { get; set; }

        /// <summary>The string identifier, if you care about it. Only guaranteed unique within the specific Milestone.</summary>
        [JsonPropertyName("rewardEntryIdentifier")]
        public string RewardEntryIdentifier { get; set; }

        /// <summary>The items you will get as rewards, and how much of it you'll get.</summary>
        [JsonPropertyName("items")]
        public IEnumerable<Destiny.DestinyItemQuantity> Items { get; set; }

        /// <summary>If this reward is redeemed at a Vendor, this is the hash of the Vendor to go to in order to redeem the reward. Use this hash to look up the DestinyVendorDefinition.</summary>
        [JsonPropertyName("vendorHash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? VendorHash { get; set; }

        /// <summary>For us to bother returning this info, we should be able to return some kind of information about why these rewards are grouped together. This is ideally that information. Look at how confident I am that this will always remain true.</summary>
        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        /// <summary>If you want to follow BNet's ordering of these rewards, use this number within a given category to order the rewards. Yeah, I know. I feel dirty too.</summary>
        [JsonPropertyName("order")]
        public int Order { get; set; }
    }

    /// <summary>
    /// If the Milestone or a component has vendors whose inventories could/should be displayed that are relevant to it, this will return the vendor in question.
    /// It also contains information we need to determine whether that vendor is actually relevant at the moment, given the user's current state.
    /// </summary>
    public class DestinyMilestoneVendorDefinition
    {
        /// <summary>The hash of the vendor whose wares should be shown as associated with the Milestone.</summary>
        [JsonPropertyName("vendorHash")]
        public uint VendorHash { get; set; }
    }

    /// <summary>
    /// The definition for information related to a key/value pair that is relevant for a particular Milestone or component within the Milestone.
    /// This lets us more flexibly pass up information that's useful to someone, even if it's not necessarily us.
    /// </summary>
    public class DestinyMilestoneValueDefinition
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("displayProperties")]
        public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }
    }

    public class DestinyMilestoneChallengeActivityDefinition
    {
        /// <summary>The activity for which this challenge is active.</summary>
        [JsonPropertyName("activityHash")]
        public uint ActivityHash { get; set; }

        [JsonPropertyName("challenges")]
        public IEnumerable<Destiny.Definitions.Milestones.DestinyMilestoneChallengeDefinition> Challenges { get; set; }

        /// <summary>If the activity and its challenge is visible on any of these nodes, it will be returned.</summary>
        [JsonPropertyName("activityGraphNodes")]
        public IEnumerable<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityGraphNodeEntry> ActivityGraphNodes { get; set; }

        /// <summary>
        /// Phases related to this activity, if there are any.
        /// These will be listed in the order in which they will appear in the actual activity.
        /// </summary>
        [JsonPropertyName("phases")]
        public IEnumerable<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityPhase> Phases { get; set; }
    }

    public class DestinyMilestoneChallengeDefinition
    {
        /// <summary>The challenge related to this milestone.</summary>
        [JsonPropertyName("challengeObjectiveHash")]
        public uint ChallengeObjectiveHash { get; set; }
    }

    public class DestinyMilestoneChallengeActivityGraphNodeEntry
    {
        [JsonPropertyName("activityGraphHash")]
        public uint ActivityGraphHash { get; set; }

        [JsonPropertyName("activityGraphNodeHash")]
        public uint ActivityGraphNodeHash { get; set; }
    }

    public class DestinyMilestoneChallengeActivityPhase
    {
        /// <summary>The hash identifier of the activity's phase.</summary>
        [JsonPropertyName("phaseHash")]
        public uint PhaseHash { get; set; }
    }
}