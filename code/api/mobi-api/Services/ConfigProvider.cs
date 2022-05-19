namespace mobi_api.Services
{
    public interface IConfigProvider
    {
        string GoogleAuthClientId();
        string GoogleAuthClientSecret();
        string GoogleAuthClientRedirectUrl();
        string GoogleAuthClientCallBackUrl();
        string GoogleAuthScope();
    }

    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration Configuration;
        public ConfigProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GoogleAuthClientId()
        {
            return Configuration["Auth:Google:ClientId"];
        }
        public string GoogleAuthClientSecret()
        {
            return Configuration["Auth:Google:ClientSecret"];
        }
        public string GoogleAuthClientRedirectUrl()
        {
            return Configuration["Auth:Google:RedirectUrl"];
        }
        public string GoogleAuthClientCallBackUrl()
        {
            return Configuration["Auth:Google:CallBackUrl"];
        }
        public string GoogleAuthScope()
        {
            return Configuration["Auth:Google:Scope"];
        }
    }
}
