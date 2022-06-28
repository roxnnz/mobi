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
        ProductDto UpdateProductByProductId(Guid StoreId, UpdateProductDto updateProductDto);
        void DeleteProductByProductId(Guid productId);
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

            if (exProductEntity == null) return null;

            else return exProductEntity.EProductDto();
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

        public ProductDto UpdateProductByProductId(Guid productId, UpdateProductDto updateProductDto)
        {
            ProductEntity? updateProductEntity = _dbContext.Products.Find(productId);

            if (updateProductEntity == null) return null;

            else
            {
                updateProductEntity.ProductName = updateProductDto.ProductName;

                updateProductEntity.Description = updateProductDto.Description;

                updateProductEntity.Price = updateProductDto.Price;

                _dbContext.SaveChanges();

                return updateProductEntity.EProductDto();

            }

        }

        public void DeleteProductByProductId(Guid productId)
        {
            var existProductEntity = _dbContext.Products.Find(productId);

            _dbContext.Remove(existProductEntity);

            _dbContext.SaveChanges();
        }
    }
}



