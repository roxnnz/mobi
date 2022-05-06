using Microsoft.AspNetCore.Mvc;
using mobi_api.Repository;
using mobi_api.DAO;

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
        public ActionResult<List<UserEntity>> Get()
        {
            return Ok(this.userRepository.GetAllUsers());
        }

        [HttpGet("{UserId}")]
        public ActionResult<UserEntity> GetUserByUserId([FromRoute] Guid UserId)
        {
            try
            {
                var result = userRepository.GetUserByUserId(UserId);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public IActionResult Update(Guid UserId, UserEntity UserDetail)
        {
            userRepository.UpdateUser(UserId, UserDetail);
            return Ok(new { message = "User updated" });
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
