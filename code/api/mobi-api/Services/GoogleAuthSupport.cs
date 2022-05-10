using mobi_api.Model;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace mobi_api.Services
{
    public interface IGoogleAuthSupport
    {
        Task<GoogleAuthResponse> GetIdToken(string Code);
    }

    public class GoogleAuthSupport : IGoogleAuthSupport
    {
        public GoogleAuthSupport()
        {

        }

        public async Task<GoogleAuthResponse> GetIdToken(string Code)
        {
            HttpClient clientB = GoogleAuthHttpClient();

            var responses = await clientB.SendAsync(GoogleAuthTokenExchangeRequest(Code));
            var stringsB = await responses.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GoogleAuthResponse>(stringsB);

        }

        private HttpClient GoogleAuthHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://www.googleapis.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            return client;
        }

        private HttpRequestMessage GoogleAuthTokenExchangeRequest(string Code)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, "/oauth2/v4/token");

            var UrlParams = new Dictionary<string, string>{
                { "client_id", "687715750173-q94u8v476nojdrtpjql08uqebsisuoda.apps.googleusercontent.com" },
                { "client_secret", "" },
                { "grant_type", "authorization_code" },
                { "redirect_uri", "https://localhost:7086/api/callback" },
                { "code", Code}
            }; 

            req.Content = new FormUrlEncodedContent(UrlParams);

            return req;
        }
    }

}
