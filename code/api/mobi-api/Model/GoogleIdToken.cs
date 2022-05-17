using System.Text.Json.Serialization;

namespace mobi_api.Model
{
    public class GoogleIdToken
    {
        [JsonPropertyName("iss")]
        public string Iss { get; set; }

        [JsonPropertyName("azp")]
        public string Azp { get; set; }

        [JsonPropertyName("aud")]
        public string Aud { get; set; }

        [JsonPropertyName("sub")]
        public string Sub { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonPropertyName("at_hash")]
        public string AtHash { get; set; }

        [JsonPropertyName("iat")]
        public int Iat { get; set; }

        [JsonPropertyName("exp")]
        public int Exp { get; set; }
    }
}