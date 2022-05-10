namespace mobi_api.Services
{
    public interface IGoogleAuthSupport
    {
        Task<string> GetIdToken(string Code);
    }

    public class GoogleAuthSupport : IGoogleAuthSupport
    {
        public GoogleAuthSupport()
        {

        }

        public async Task<string> GetIdToken(string Code)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.SendAsync(GoogleAuthTokenExchangeRequest(Code));

                return await response.Content.ReadAsStringAsync();
            } catch (Exception ex)
            {
                return null;
            }
            
        }

        private HttpRequestMessage GoogleAuthTokenExchangeRequest(string Code)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, "https://oauth2.googleapis.com/token");

            var UrlParams = new Dictionary<string, string>{
                { "client_id", "687715750173-q94u8v476nojdrtpjql08uqebsisuoda.apps.googleusercontent.com" },
                { "client_secret", "" },
                { "grant_type", "authorization_code" },
                { "redirect_uri", "https%3A//localhost:7086/api/callback" },
                { "code", Code}
            };

            req.Content = new FormUrlEncodedContent(UrlParams);

            return req;
        }
    }

}
