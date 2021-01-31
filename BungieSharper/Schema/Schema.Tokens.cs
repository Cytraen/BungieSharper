using System;
using System.Collections.Generic;

namespace BungieSharper.Schema.Tokens
{
    public class PartnerOfferClaimRequest
    {
        public string PartnerOfferId { get; set; }
        public long BungieNetMembershipId { get; set; }
        public string TransactionId { get; set; }
    }

    public class PartnerOfferSkuHistoryResponse
    {
        public string SkuIdentifier { get; set; }
        public string LocalizedName { get; set; }
        public string LocalizedDescription { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool AllOffersApplied { get; set; }
        public string TransactionId { get; set; }
        public IEnumerable<Schema.Tokens.PartnerOfferHistoryResponse> SkuOffers { get; set; }
    }

    public class PartnerOfferHistoryResponse
    {
        public string PartnerOfferKey { get; set; }
        public long? MembershipId { get; set; }
        public int? MembershipType { get; set; }
        public string LocalizedName { get; set; }
        public string LocalizedDescription { get; set; }
        public bool IsConsumable { get; set; }
        public int QuantityApplied { get; set; }
        public DateTime? ApplyDate { get; set; }
    }
}