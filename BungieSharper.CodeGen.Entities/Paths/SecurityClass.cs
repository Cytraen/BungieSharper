using BungieSharper.CodeGen.Entities.Common;
using System.Text.Json.Serialization;

namespace BungieSharper.CodeGen.Entities.Paths
{
    public class SecurityClass
    {
        [JsonPropertyName("oauth2"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OAuthScopeEnum[] OAuth2 { get; set; }
    }
}