using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Tokens
{
    public class PartnerOfferClaimRequest
    {
        [JsonPropertyName("PartnerOfferId")]
        public string PartnerOfferId { get; set; }

        [JsonPropertyName("BungieNetMembershipId")]
        public long BungieNetMembershipId { get; set; }

        [JsonPropertyName("TransactionId")]
        public string TransactionId { get; set; }
    }

    public class PartnerOfferSkuHistoryResponse
    {
        [JsonPropertyName("SkuIdentifier")]
        public string SkuIdentifier { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("LocalizedDescription")]
        public string LocalizedDescription { get; set; }

        [JsonPropertyName("ClaimDate")]
        public DateTime ClaimDate { get; set; }

        [JsonPropertyName("AllOffersApplied")]
        public bool AllOffersApplied { get; set; }

        [JsonPropertyName("TransactionId")]
        public string TransactionId { get; set; }

        [JsonPropertyName("SkuOffers")]
        public IEnumerable<Tokens.PartnerOfferHistoryResponse> SkuOffers { get; set; }
    }

    public class PartnerOfferHistoryResponse
    {
        [JsonPropertyName("PartnerOfferKey")]
        public string PartnerOfferKey { get; set; }

        [JsonPropertyName("MembershipId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? MembershipId { get; set; }

        [JsonPropertyName("MembershipType"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MembershipType { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("LocalizedDescription")]
        public string LocalizedDescription { get; set; }

        [JsonPropertyName("IsConsumable")]
        public bool IsConsumable { get; set; }

        [JsonPropertyName("QuantityApplied")]
        public int QuantityApplied { get; set; }

        [JsonPropertyName("ApplyDate"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ApplyDate { get; set; }
    }
}