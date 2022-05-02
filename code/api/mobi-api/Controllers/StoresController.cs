using Microsoft.AspNetCore.Mvc;
using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private IStoreRepository storeRepository;

        public StoresController(IStoreRepository StoresRepository)
        {
            this.storeRepository = StoresRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<StoreEntity>> Get()
        {
            return Ok(this.storeRepository.GetAllStores());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{StoreId}")]
        public ActionResult<StoreEntity> GetStoreByStoreId([FromRoute] Guid StoreId)
        {
            try
            {
                var result = storeRepository.GetStoreByStoreId(StoreId);

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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
