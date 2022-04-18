using FluentValidation;
using System.Text.Json.Serialization;

namespace mobi_api
{
    public class User
    {
        [JsonPropertyName("user_name")]
        public string? UserName { get; set; }

        [JsonPropertyName("user_email")]
        public string? UserEmail { get; set; }

        [JsonPropertyName("user_phone")]
        public string? UserPhone { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Please specify a first name");
            RuleFor(x => x.UserPhone).NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}