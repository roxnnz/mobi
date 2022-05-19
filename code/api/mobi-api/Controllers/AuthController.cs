using Microsoft.AspNetCore.Mvc;
using mobi_api.Model;
using mobi_api.Services;
using mobi_api.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IGoogleAuthSupport _GoogleAuthSupport;
        private readonly IUserRepository _UsersRepository;
        private readonly IJwtService _JwtService;
        private readonly IConfigProvider _ConfigProvider;

        public AuthController(IGoogleAuthSupport googleAuthSupport, 
            IUserRepository usersRepository, 
            IJwtService JwtService, 
            IConfigProvider ConfigProvider)
        {
            _GoogleAuthSupport = googleAuthSupport;
            _UsersRepository = usersRepository;
            _JwtService = JwtService;
            _ConfigProvider = ConfigProvider;
        }
        // GET: api/<AuthController>
        [HttpGet("login")]
        public IActionResult Get()
        {
            var google_login_host = "https://accounts.google.com/o/oauth2/v2/auth";
            var client_id = _ConfigProvider.GetGoogleConfig().ClientId;
            var callback_url = _ConfigProvider.GetGoogleConfig().CallBackUrl; // change to /api/auth/callback
            var state = "state_parameter_passthrough_value"; // implement state value (url path triggred)
            var scope = _ConfigProvider.GetGoogleConfig().Scope;

            var url = $"{google_login_host}?client_id={client_id}&response_type=code&state={state}&scope={scope}&redirect_uri={callback_url}&prompt=consent&include_granted_scopes=true";

            return Redirect(url);
        }

        [HttpGet("/api/callback")]
        public async Task<IActionResult> Get([FromQuery] string Code)
        {

            GoogleAuthResponse response = await _GoogleAuthSupport.GetIdToken(Code);
            var GoogleIdToken = _JwtService.ParseIdToken(response.IdToken);
            var isUserExist = _UsersRepository.IsUserExists(GoogleIdToken.Email);

            if (!isUserExist)
            {
                // Create user
                _UsersRepository.InitUser(GoogleIdToken.Email);
            }

            var website_host = "http://localhost:3000/";
            var url = $"{website_host}?idToken={response.IdToken}";

            return Redirect(url);

        }

        // POST api/<AuthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
