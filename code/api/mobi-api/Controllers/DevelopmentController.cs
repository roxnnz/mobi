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
            // Constractor
            _developmentData = DevelopmentData;
        }


        [HttpPut("generate/testdata/stores")]
        public ActionResult<List<StoreEntity>> Put(int id, [FromBody] string value)
        {
            
            Console.WriteLine(value);
            var results = _developmentData.GenereateDevelopmentData();
            if(results == null)
            {
                return Ok(null);
            }
            return Ok(results);

        }
    }
}
