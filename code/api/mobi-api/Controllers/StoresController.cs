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
        public ActionResult<StoreDto> GetAllStores()
        {
            var stores = _storeRepository.GetAllStores();

            return Ok(stores);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{storeId}")]
        public ActionResult<List<StoreDto>> GetStoreByStoreId([FromRoute] Guid storeId)
        {
            try
            {
                var store = _storeRepository.GetStoreByStoreId(storeId);

                if (store == null) return NotFound();

                else return Ok(store);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult PostNewStore([FromBody] CreateStoreDto createStoreDto)
        {
            try
            {
                StoreEntity newStore = new()
                {
                    StoreId = Guid.NewGuid(),
                    StoreName = createStoreDto.StoreName,
                    PhoneNumber = createStoreDto.PhoneNumber,
                    Address = createStoreDto.Address,
                    Website = createStoreDto.Website
                };

                _storeRepository.CreateStore(newStore);

                return Created("GetStoreByStoreId", newStore.EStoreDto());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            if (updatedStore == null) return NotFound();
            return Ok(updatedStore);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
