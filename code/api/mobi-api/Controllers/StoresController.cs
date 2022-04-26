using Microsoft.AspNetCore.Mvc;
using mobi_api.Model;
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
        public List<Store> Get()
        {
            return this.storeRepository.GetAllStores();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
