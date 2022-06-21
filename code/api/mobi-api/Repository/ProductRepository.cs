using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;
using mobi_api.Dtos;

namespace mobi_api.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductByProductId(Guid productId);
        IQueryable<ProductDto> GetProductsByStoreId(Guid storeId);
        ProductDto AddProductByStoreId(Guid storeId, ProductEntity newProduct);
        ProductResponse UpdateProductByProductId(Guid StoreId, ProductRequest product);
    }
    public class ProductsRepository : IProductRepository
    {
        private readonly MobiConsumerContext _dbContext;

        public ProductsRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var result = _dbContext.Products.Select(products => products.EProductDto());

            return result;
        }

        public ProductDto GetProductByProductId(Guid productId)
        {
            ProductEntity exProductEntity = _dbContext.Products.First(p => p.ProductId == productId);

            return exProductEntity.EProductDto();
        }

        public IQueryable<ProductDto> GetProductsByStoreId(Guid storeId)
        {
            var result = _dbContext.Products.Where(Product => Product.Store.StoreId == storeId);

            if (result == null) return null;

            else
            {
                IQueryable<ProductDto> productDtos = result.Select(products => products.EProductDto());

                return productDtos;
            }
        }


        public ProductDto? AddProductByStoreId(Guid storeId, ProductEntity newProduct)
        {
            var store = _dbContext.Stores.Find(storeId);

            if (store == null) return null;

            else
            {
                var addProduct = new ProductDto()
                {
                    ProductId = newProduct.ProductId,
                    ProductName = newProduct.ProductName,
                    Description = newProduct.Description,
                    Price = newProduct.Price
                };

                store.Products.Add(newProduct);

                _dbContext.SaveChanges();

                return addProduct;
            }
        }

        public ProductResponse? UpdateProductByProductId(Guid productId, ProductRequest productRequest)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);

            if (product == null)
                return null;

            if (product != null)
                product.ProductName = productRequest.ProductName;

            if (product != null)
                product.Description = productRequest.Description;

            if (productRequest != null)
                product.Price = productRequest.Price;

            _dbContext.SaveChanges();

            return new ProductResponse()
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
}
