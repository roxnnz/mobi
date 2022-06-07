using Microsoft.AspNetCore.Mvc;
using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Repository;
using mobi_api.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private IStoreRepository _storeRepository;

        public StoresController(IStoreRepository StoresRepository)
        {
            _storeRepository = StoresRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<StoreDto> Get()
        {
            var stores = _storeRepository.GetAllStores();
            return Ok(stores);
            //return Ok(_storeRepository.GetAllStores());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{StoreId}")]
        public ActionResult<StoreEntity> GetStoreByStoreId([FromRoute] Guid StoreId)
        {
            try
            {
                var result = _storeRepository.GetStoreByStoreId(StoreId);

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
        public ActionResult<StoreResponse> Post([FromBody] StoreRequest StoreRequest)
        {
            var storeResponse = _storeRepository.CreateStore(StoreRequest);            
            return Ok(storeResponse);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPatch("{StoreId}")]
        public ActionResult<StoreResponse> Patch([FromRoute] Guid StoreId, [FromBody] StoreRequest StoreRequest)
        {
            var updatedStore = _storeRepository.UpdateStoreByStoreId(StoreId, StoreRequest);
            if(updatedStore == null) return NotFound();
            return Ok(updatedStore);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
