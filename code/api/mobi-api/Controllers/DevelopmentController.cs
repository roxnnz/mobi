using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobi_api.DAO;
using mobi_api.Services;

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentController : ControllerBase
    {
        private readonly IDevelopmentData _developmentData;
        public DevelopmentController(IDevelopmentData DevelopmentData)
        {
            _developmentData = DevelopmentData;
        }

        [HttpPut("generate/testdata/products")]
        public ActionResult<List<StoreEntity>> PutProducts()
        {
            var results = _developmentData.GenerateDevelopmentDataProducts();
            return Ok(results);
        }

        [HttpPut("generate/testdata/stores")]
        public ActionResult<List<StoreEntity>> PutStores()
        {
            var results = _developmentData.GenerateDevelopmentDataStores();
            return Ok(results);
        }
    }
}
