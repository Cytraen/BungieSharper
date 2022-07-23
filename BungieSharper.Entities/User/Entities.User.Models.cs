using System.Text.Json.Serialization;

namespace BungieSharper.Entities.User.Models
{
    public class GetCredentialTypesForAccountResponse
    {
        [JsonPropertyName("credentialType")]
        public BungieCredentialType CredentialType { get; set; }

        [JsonPropertyName("credentialDisplayName")]
        public string CredentialDisplayName { get; set; }

        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; }

        [JsonPropertyName("credentialAsString")]
        public string CredentialAsString { get; set; }
    }

    [JsonSerializable(typeof(GetCredentialTypesForAccountResponse))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class GetCredentialTypesForAccountResponseJsonContext : JsonSerializerContext { }
}