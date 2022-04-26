using Microsoft.AspNetCore.Mvc;
using mobi_api.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository userRepository;

        public UsersController(IUserRepository UsersRepository)
        {
            this.userRepository = UsersRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public List<User> Get()
        {
            return this.userRepository.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{FirstName}")]
        public ActionResult<User> GetUserByFirstName([FromRoute]String FirstName)
        {
            try
            {
                var result = userRepository.GetUserByFirstName(FirstName);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
