namespace mobi_api.Services
{
    public interface IConfigProvider
    {
        GoogleConfigs GetGoogleConfig();
    }

    public class GoogleConfigs
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? RedirectUrl { get; set; }
        public string? CallBackUrl { get; set; }
        public string? Scope { get; set; }
    }

    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration Configuration;
        public ConfigProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public GoogleConfigs GetGoogleConfig()
        {
            // TODO: not sure this exceptoin works as expected. No unit testing.
            if(Configuration["Auth:Google"] == null)
            {
                throw new ArgumentNullException();
            }

            return new GoogleConfigs()
            {
                ClientId = Configuration["Auth:Google:ClientId"],
                ClientSecret = Configuration["Auth:Google:ClientSecret"],
                RedirectUrl = Configuration["Auth:Google:RedirectUrl"],
                CallBackUrl = Configuration["Auth:Google:CallBackUrl"],
                Scope = Configuration["Auth:Google:Scope"]
            };
        }
    }
}
