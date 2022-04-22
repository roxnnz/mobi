using FluentValidation;
using System.Text.Json.Serialization;

namespace mobi_api
{
    public class User
    {
        [JsonPropertyName("User")]
        public string FirstName { get; set; } = "No firstname found";
        public string LastName { get; set; } = "No lastname found";
        public string Email { get; set; } = "No email found";
        public string Phone { get; set; } = "No phone number found";
    }

}