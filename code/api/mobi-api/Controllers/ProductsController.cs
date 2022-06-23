using Microsoft.AspNetCore.Mvc;
using mobi_api.Repository;
using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Dtos;

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

        [HttpGet("[action]")]
        public ActionResult<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("[action]/{productId}")]
        public ActionResult<ProductDto> GetProductByProductId(Guid productId)
        {
            try
            {
                var productByProductId = _productRepository.GetProductByProductId(productId);

                if (productByProductId == null) return NotFound();

                else return Ok(productByProductId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error retrieving data from the database");
            }
        }

        [Route("[action]/{storeId}")]
        [HttpGet]
        public ActionResult<List<ProductDto>> GetProductsByStoreId(Guid storeId)
        {
            try
            {
                var productsByStoreId = _productRepository.GetProductsByStoreId(storeId);

                if (productsByStoreId == null) return NotFound();

                else return Ok(productsByStoreId);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Incorrect StoreId");
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("[action]{storeId}")]
        public ActionResult<ProductDto> PutProductByStoreId([FromRoute] Guid storeId, [FromBody] CreateProductDto createProductDto)
        {
            try
            {
                ProductEntity newProduct = new()
                {
                    ProductName = createProductDto.ProductName,
                    Description = createProductDto.Description,
                    Price = createProductDto.Price
                };

                ProductDto result = _productRepository.AddProductByStoreId(storeId, newProduct);

                if (result == null) return NotFound();

                else return Created("GetProductsByStoreId", newProduct.EProductDto());
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("[action]/{id}")]
        public void delete(int id)
        {
        }
    }
}
