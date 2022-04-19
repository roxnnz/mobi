using Microsoft.AspNetCore.Mvc;
using mobi_api.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository ProductRepository)
        {
            this.productRepository = ProductRepository;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return this.productRepository.GetAllProducts();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void delete(int id)
        {
        }
    }
}
