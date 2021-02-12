﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Sockets
{
    public class DestinyItemPlugBase
    {
        /// <summary>The hash identifier of the DestinyInventoryItemDefinition that represents this plug.</summary>
        [JsonPropertyName("plugItemHash")]
        public uint PlugItemHash { get; set; }

        /// <summary>If true, this plug has met all of its insertion requirements. Big if true.</summary>
        [JsonPropertyName("canInsert")]
        public bool CanInsert { get; set; }

        /// <summary>If true, this plug will provide its benefits while inserted.</summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// If the plug cannot be inserted for some reason, this will have the indexes into the plug item definition's plug.insertionRules property, so you can show the reasons why it can't be inserted.
        /// This list will be empty if the plug can be inserted.
        /// </summary>
        [JsonPropertyName("insertFailIndexes")]
        public IEnumerable<int> InsertFailIndexes { get; set; }

        /// <summary>
        /// If a plug is not enabled, this will be populated with indexes into the plug item definition's plug.enabledRules property, so that you can show the reasons why it is not enabled.
        /// This list will be empty if the plug is enabled.
        /// </summary>
        [JsonPropertyName("enableFailIndexes")]
        public IEnumerable<int> EnableFailIndexes { get; set; }
    }

    public class DestinyItemPlug
    {
        /// <summary>Sometimes, Plugs may have objectives: these are often used for flavor and display purposes, but they can be used for any arbitrary purpose (both fortunately and unfortunately). Recently (with Season 2) they were expanded in use to be used as the "gating" for whether the plug can be inserted at all. For instance, a Plug might be tracking the number of PVP kills you have made. It will use the parent item's data about that tracking status to determine what to show, and will generally show it using the DestinyObjectiveDefinition's progressDescription property. Refer to the plug's itemHash and objective property for more information if you would like to display even more data.</summary>
        [JsonPropertyName("plugObjectives")]
        public IEnumerable<Destiny.Quests.DestinyObjectiveProgress> PlugObjectives { get; set; }

        /// <summary>The hash identifier of the DestinyInventoryItemDefinition that represents this plug.</summary>
        [JsonPropertyName("plugItemHash")]
        public uint PlugItemHash { get; set; }

        /// <summary>If true, this plug has met all of its insertion requirements. Big if true.</summary>
        [JsonPropertyName("canInsert")]
        public bool CanInsert { get; set; }

        /// <summary>If true, this plug will provide its benefits while inserted.</summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// If the plug cannot be inserted for some reason, this will have the indexes into the plug item definition's plug.insertionRules property, so you can show the reasons why it can't be inserted.
        /// This list will be empty if the plug can be inserted.
        /// </summary>
        [JsonPropertyName("insertFailIndexes")]
        public IEnumerable<int> InsertFailIndexes { get; set; }

        /// <summary>
        /// If a plug is not enabled, this will be populated with indexes into the plug item definition's plug.enabledRules property, so that you can show the reasons why it is not enabled.
        /// This list will be empty if the plug is enabled.
        /// </summary>
        [JsonPropertyName("enableFailIndexes")]
        public IEnumerable<int> EnableFailIndexes { get; set; }
    }
}