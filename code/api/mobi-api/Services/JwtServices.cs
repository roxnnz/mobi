using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using mobi_api.Model;
using System.Text.Json;

// Get from https://jwt.io/libraries

namespace mobi_api.Services
{
    public interface IJwtService
    {
        GoogleIdToken ParseIdToken(string idToken);
    }
    public class JwtServices : IJwtService
    {
        public JwtServices()
        {

        } 

        public GoogleIdToken ParseIdToken(string idToken)
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

            var json = decoder.Decode(idToken);
            GoogleIdToken googleIdContext = JsonSerializer.Deserialize<GoogleIdToken>(json);
            return googleIdContext;
        }
    }

    
}
