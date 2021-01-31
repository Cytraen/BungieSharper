using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Vendors
{
    /// <summary>
    /// If a character purchased an item that is refundable, a Vendor Receipt will be created on the user's Destiny Profile. These expire after a configurable period of time, but until then can be used to get refunds on items. BNet does not provide the ability to refund a purchase *yet*, but you know.
    /// </summary>
    public class DestinyVendorReceipt
    {
        /// <summary>The amount paid for the item, in terms of items that were consumed in the purchase and their quantity.</summary>
        public IEnumerable<Destiny.DestinyItemQuantity> currencyPaid { get; set; }

        /// <summary>The item that was received, and its quantity.</summary>
        public Destiny.DestinyItemQuantity itemReceived { get; set; }

        /// <summary>The unlock flag used to determine whether you still have the purchased item.</summary>
        public uint licenseUnlockHash { get; set; }

        /// <summary>The ID of the character who made the purchase.</summary>
        public long purchasedByCharacterId { get; set; }

        /// <summary>Whether you can get a refund, and what happens in order for the refund to be received. See the DestinyVendorItemRefundPolicy enum for details.</summary>
        public Destiny.DestinyVendorItemRefundPolicy refundPolicy { get; set; }

        /// <summary>The identifier of this receipt.</summary>
        public int sequenceNumber { get; set; }

        /// <summary>The seconds since epoch at which this receipt is rendered invalid.</summary>
        public long timeToExpiration { get; set; }

        /// <summary>The date at which this receipt is rendered invalid.</summary>
        public DateTime expiresOn { get; set; }
    }
}