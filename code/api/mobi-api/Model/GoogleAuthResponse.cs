using System.Text.Json.Serialization;

namespace mobi_api.Model
{
    public class GoogleAuthResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { set; get;}

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { set; get;}

        public string Scope { set; get;}

        [JsonPropertyName("token_type")]
        public string TokenType { set; get;}

        [JsonPropertyName("id_token")]
        public string IdToken { set; get;}
    }
}
