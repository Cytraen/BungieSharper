﻿using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Entities.Profiles
{

    /// <summary>
    /// For now, this isn't used for much: it's a record of the recent refundable purchases that the user has made. In the future, it could be used for providing refunds/buyback via the API. Wouldn't that be fun?
    /// </summary>
    public class DestinyVendorReceiptsComponent
    {
        /// <summary>The receipts for refundable purchases made at a vendor.</summary>
        public IEnumerable<Schema.Destiny.Vendors.DestinyVendorReceipt> receipts { get; set; }
    }

    /// <summary>
    /// The most essential summary information about a Profile (in Destiny 1, we called these "Accounts").
    /// </summary>
    public class DestinyProfileComponent
    {
        /// <summary>If you need to render the Profile (their platform name, icon, etc...) somewhere, this property contains that information.</summary>
        public Schema.User.UserInfoCard userInfo { get; set; }
        /// <summary>The last time the user played with any character on this Profile.</summary>
        public DateTime dateLastPlayed { get; set; }
        /// <summary>
        /// If you want to know what expansions they own, this will contain that data.
        ///  IMPORTANT: This field may not return the data you're interested in for Cross-Saved users. It returns the last ownership data we saw for this account - which is to say, what they've purchased on the platform on which they last played, which now could be a different platform.
        ///  If you don't care about per-platform ownership and only care about whatever platform it seems they are playing on most recently, then this should be "good enough." Otherwise, this should be considered deprecated. We do not have a good alternative to provide at this time with platform specific ownership data for DLC.
        /// </summary>
        public Schema.Destiny.DestinyGameVersions versionsOwned { get; set; }
        /// <summary>A list of the character IDs, for further querying on your part.</summary>
        public IEnumerable<long> characterIds { get; set; }
        /// <summary>
        /// A list of seasons that this profile owns. Unlike versionsOwned, these stay with the profile across Platforms, and thus will be valid.
        ///  It turns out that Stadia Pro subscriptions will give access to seasons but only while playing on Stadia and with an active subscription. So some users (users who have Stadia Pro but choose to play on some other platform) won't see these as available: it will be whatever seasons are available for the platform on which they last played.
        /// </summary>
        public IEnumerable<uint> seasonHashes { get; set; }
        /// <summary>If populated, this is a reference to the season that is currently active.</summary>
        public uint currentSeasonHash { get; set; }
    }
}