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

    [JsonSerializable(typeof(PartnerOfferClaimRequest))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class PartnerOfferClaimRequestJsonContext : JsonSerializerContext { }

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

    [JsonSerializable(typeof(PartnerOfferSkuHistoryResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class PartnerOfferSkuHistoryResponseJsonContext : JsonSerializerContext { }

    public class PartnerOfferHistoryResponse
    {
        [JsonPropertyName("PartnerOfferKey")]
        public string PartnerOfferKey { get; set; }

        [JsonPropertyName("MembershipId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? MembershipId { get; set; }

        [JsonPropertyName("MembershipType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MembershipType { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("LocalizedDescription")]
        public string LocalizedDescription { get; set; }

        [JsonPropertyName("IsConsumable")]
        public bool IsConsumable { get; set; }

        [JsonPropertyName("QuantityApplied")]
        public int QuantityApplied { get; set; }

        [JsonPropertyName("ApplyDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ApplyDate { get; set; }
    }

    [JsonSerializable(typeof(PartnerOfferHistoryResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class PartnerOfferHistoryResponseJsonContext : JsonSerializerContext { }

    public class BungieRewardDisplay
    {
        [JsonPropertyName("UserRewardAvailabilityModel")]
        public Tokens.UserRewardAvailabilityModel UserRewardAvailabilityModel { get; set; }

        [JsonPropertyName("ObjectiveDisplayProperties")]
        public Tokens.RewardDisplayProperties ObjectiveDisplayProperties { get; set; }

        [JsonPropertyName("RewardDisplayProperties")]
        public Tokens.RewardDisplayProperties RewardDisplayProperties { get; set; }
    }

    [JsonSerializable(typeof(BungieRewardDisplay))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class BungieRewardDisplayJsonContext : JsonSerializerContext { }

    public class UserRewardAvailabilityModel
    {
        [JsonPropertyName("AvailabilityModel")]
        public Tokens.RewardAvailabilityModel AvailabilityModel { get; set; }

        [JsonPropertyName("IsAvailableForUser")]
        public bool IsAvailableForUser { get; set; }

        [JsonPropertyName("IsUnlockedForUser")]
        public bool IsUnlockedForUser { get; set; }
    }

    [JsonSerializable(typeof(UserRewardAvailabilityModel))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class UserRewardAvailabilityModelJsonContext : JsonSerializerContext { }

    public class RewardAvailabilityModel
    {
        [JsonPropertyName("HasExistingCode")]
        public bool HasExistingCode { get; set; }

        [JsonPropertyName("RecordDefinitions")]
        public IEnumerable<Destiny.Definitions.Records.DestinyRecordDefinition> RecordDefinitions { get; set; }

        [JsonPropertyName("CollectibleDefinitions")]
        public IEnumerable<Tokens.CollectibleDefinitions> CollectibleDefinitions { get; set; }

        [JsonPropertyName("IsOffer")]
        public bool IsOffer { get; set; }

        [JsonPropertyName("HasOffer")]
        public bool HasOffer { get; set; }

        [JsonPropertyName("OfferApplied")]
        public bool OfferApplied { get; set; }

        [JsonPropertyName("DecryptedToken")]
        public string DecryptedToken { get; set; }

        [JsonPropertyName("IsLoyaltyReward")]
        public bool IsLoyaltyReward { get; set; }

        [JsonPropertyName("ShopifyEndDate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ShopifyEndDate { get; set; }

        [JsonPropertyName("GameEarnByDate")]
        public DateTime GameEarnByDate { get; set; }

        [JsonPropertyName("RedemptionEndDate")]
        public DateTime RedemptionEndDate { get; set; }
    }

    [JsonSerializable(typeof(RewardAvailabilityModel))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class RewardAvailabilityModelJsonContext : JsonSerializerContext { }

    public class CollectibleDefinitions
    {
        [JsonPropertyName("CollectibleDefinition")]
        public Destiny.Definitions.Collectibles.DestinyCollectibleDefinition CollectibleDefinition { get; set; }

        [JsonPropertyName("DestinyInventoryItemDefinition")]
        public Destiny.Definitions.DestinyInventoryItemDefinition DestinyInventoryItemDefinition { get; set; }
    }

    [JsonSerializable(typeof(CollectibleDefinitions))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class CollectibleDefinitionsJsonContext : JsonSerializerContext { }

    public class RewardDisplayProperties
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("ImagePath")]
        public string ImagePath { get; set; }
    }

    [JsonSerializable(typeof(RewardDisplayProperties))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class RewardDisplayPropertiesJsonContext : JsonSerializerContext { }
}