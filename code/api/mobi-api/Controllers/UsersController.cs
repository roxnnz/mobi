using Microsoft.AspNetCore.Mvc;
using mobi_api.Repository;
using mobi_api.DAO;
using mobi_api.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository UsersRepository)
        {
            _userRepository = UsersRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<UsersEntity>> Get()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        // GET api/<UsersController>/5
        [HttpGet("{UserId}")]
        public ActionResult<UserDto> GetUserByFirstName([FromRoute]Guid UserId)
        {
            try
            {
                var result = _userRepository.GetUserByUserId(UserId);

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
        [HttpPut("{UserId}")]
        public ActionResult<UsersEntity> Put(Guid UserId, [FromBody] UpdateUserRequest User)
        {
            if(UserId == null)
                throw new ArgumentNullException("userId");

            var _user = _userRepository.UpdateUserByUserId(UserId, User);
            return Ok(_user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
