using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET: api/<AuthController>
        [HttpGet("login")]
        public IActionResult Get()
        {
            var google_login_host = "https://accounts.google.com/o/oauth2/v2/auth";
            var client_id = "687715750173-q94u8v476nojdrtpjql08uqebsisuoda.apps.googleusercontent.com";
            var callback_url = "https%3A//localhost:7086/api/callback"; // change to /api/auth/callback
            var state = "state_parameter_passthrough_value"; // implement state value (url path triggred)
            var scope = "https%3A//www.googleapis.com/auth/drive.file"; // change scope to identity only

            var url = $"{google_login_host}?client_id={client_id}&response_type=code&state={state}&scope={scope}&redirect_uri={callback_url}&prompt=consent&include_granted_scopes=true";

            return Redirect(url);
        }

        [HttpGet("/api/callback")]
        public IActionResult Get([FromQuery] string Code)
        {
            Console.WriteLine(Code);

            // TODO: impment token exchange. 
            var AccessToken = Code;

            var website_host = "http://localhost:3000/";
            var url = $"{website_host}?accessToken={AccessToken}";

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
