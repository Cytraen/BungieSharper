namespace BungieSharper.Schema.Destiny.Constants
{
    public class DestinyEnvironmentLocationMapping
    {
        /// <summary>The location that is revealed on the director by this mapping.</summary>
        public uint locationHash { get; set; }
        /// <summary>A hint that the UI uses to figure out how this location is activated by the player.</summary>
        public string activationSource { get; set; }
        /// <summary>If this is populated, it is the item that you must possess for this location to be active because of this mapping. (theoretically, a location can have multiple mappings, and some might require an item while others don't)</summary>
        public uint? itemHash { get; set; }
        /// <summary>If this is populated, this is an objective related to the location.</summary>
        public uint? objectiveHash { get; set; }
        /// <summary>If this is populated, this is the activity you have to be playing in order to see this location appear because of this mapping. (theoretically, a location can have multiple mappings, and some might require you to be in a specific activity when others don't)</summary>
        public uint? activityHash { get; set; }
    }
}