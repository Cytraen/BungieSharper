namespace BungieSharper.Schema.User.Models
{
    public class GetCredentialTypesForAccountResponse
    {
        public Schema.BungieCredentialType credentialType { get; set; }
        public string credentialDisplayName { get; set; }
        public bool isPublic { get; set; }
        public string credentialAsString { get; set; }
    }
}