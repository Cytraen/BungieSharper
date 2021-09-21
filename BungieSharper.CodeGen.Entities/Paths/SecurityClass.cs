using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class SecurityClass
    {
        [JsonPropertyName("oauth2")]
        public OAuthScopeEnum[] OAuth2 { get; set; }
    }
}