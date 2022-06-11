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
        public ActionResult<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("api/{storeId}")]        
        public ActionResult<List<ProductDto>> GetProductsByStoreId(Guid storeId)
        {
            try
            {
                var products = _productRepository.GetProductsByStoreId(storeId);

                if (products == null) {return NotFound();}

                else {return Ok(products);}                
            }

            catch (Exception)
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
        [HttpPut("{storeId}")]
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

                if (result == null) { return NotFound(); }
                else
                {
                    return Created("GetProductsByStoreId", newProduct.EProductDto());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void delete(int id)
        {
        }
    }
}
