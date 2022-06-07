using Microsoft.AspNetCore.Mvc;
using mobi_api.Repository;
using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Dtos;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mobi_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;
        }

        [HttpGet]
        public ActionResult<ProductDto> Get()
        {
            var products = _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("api/{storeId}")]
        public ActionResult<List<ProductDto>> get(Guid storeId)
        {
            try
            {
                var products = _productRepository.GetProductsByStoreId(storeId);

                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }

            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Incorrect StoreId");
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{StoreId}")]
        public ActionResult<ProductResponse> Put([FromRoute] Guid StoreId, [FromBody] Product Product)
        {
            var newProduct = _productRepository.AddProductForStore(StoreId, Product);
            return newProduct;
        }

        [HttpPatch("{ProductId}")]
        public ActionResult<ProductResponse> Patch([FromRoute] Guid ProductId, [FromBody] ProductRequest productRequest)
        {
            var updatedProduct = _productRepository.UpdateProductByProductId(ProductId, productRequest);
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void delete(int id)
        {
        }
    }
}
