using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentController : ControllerBase
    {
        public DevelopmentController()
        {
            // Constractor
        }


        [HttpPut("generate/testdata/all")]
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine(value);
        }
    }
}
