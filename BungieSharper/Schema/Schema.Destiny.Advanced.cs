using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Advanced
{
    public class AwaInitializeResponse
    {
        /// <summary>ID used to get the token. Present this ID to the user as it will identify this specific request on their device.</summary>
        public string correlationId { get; set; }
        /// <summary>True if the PUSH message will only be sent to the device that made this request.</summary>
        public bool sentToSelf { get; set; }
    }

    public class AwaPermissionRequested
    {
        /// <summary>Type of advanced write action.</summary>
        public Schema.Destiny.Advanced.AwaType type { get; set; }
        /// <summary>Item instance ID the action shall be applied to. This is optional for all but a new AwaType values. Rule of thumb is to provide the item instance ID if one is available.</summary>
        public long? affectedItemId { get; set; }
        /// <summary>Destiny membership type of the account to modify.</summary>
        public Schema.BungieMembershipType membershipType { get; set; }
        /// <summary>Destiny character ID, if applicable, that will be affected by the action.</summary>
        public long? characterId { get; set; }
    }

    public enum AwaType
    {
        None = 0,
        /// <summary>Insert plugs into sockets.</summary>
        InsertPlugs = 1
    }

    public class AwaUserResponse
    {
        /// <summary>Indication of the selection the user has made (Approving or rejecting the action)</summary>
        public Schema.Destiny.Advanced.AwaUserSelection selection { get; set; }
        /// <summary>Correlation ID of the request</summary>
        public string correlationId { get; set; }
        /// <summary>Secret nonce received via the PUSH notification.</summary>
        public IEnumerable<byte> nonce { get; set; }
    }

    public enum AwaUserSelection
    {
        None = 0,
        Rejected = 1,
        Approved = 2
    }

    public class AwaAuthorizationResult
    {
        /// <summary>Indication of how the user responded to the request. If the value is "Approved" the actionToken will contain the token that can be presented when performing the advanced write action.</summary>
        public Schema.Destiny.Advanced.AwaUserSelection userSelection { get; set; }
        public Schema.Destiny.Advanced.AwaResponseReason responseReason { get; set; }
        /// <summary>Message to the app developer to help understand the response.</summary>
        public string developerNote { get; set; }
        /// <summary>Credential used to prove the user authorized an advanced write action.</summary>
        public string actionToken { get; set; }
        /// <summary>This token may be used to perform the requested action this number of times, at a maximum. If this value is 0, then there is no limit.</summary>
        public int maximumNumberOfUses { get; set; }
        /// <summary>Time, UTC, when token expires.</summary>
        public DateTime? validUntil { get; set; }
        /// <summary>Advanced Write Action Type from the permission request.</summary>
        public Schema.Destiny.Advanced.AwaType type { get; set; }
        /// <summary>MembershipType from the permission request.</summary>
        public Schema.BungieMembershipType membershipType { get; set; }
    }

    public enum AwaResponseReason
    {
        None = 0,
        /// <summary>User provided an answer</summary>
        Answered = 1,
        /// <summary>The HTTP request timed out, a new request may be made and an answer may still be provided.</summary>
        TimedOut = 2,
        /// <summary>This request was replaced by another request.</summary>
        Replaced = 3
    }
}