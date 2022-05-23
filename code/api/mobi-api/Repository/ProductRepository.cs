using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;
using System.Text.Json;


namespace mobi_api.Repository
{
    public interface IProductRepository
    {
        List<ProductEntity> GetAllProducts();
        List<ProductEntity> GetProductByStoreId(Guid StoreId);
        ProductResponse AddProductForStore(Guid StoreId, Product Product);
    }
    public class ProductsRepository : IProductRepository
    {
        private readonly MobiConsumerContext _dbContext;
        public ProductsRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public List<ProductEntity> GetProductByStoreId(Guid StoreId)
        {
            var store = _dbContext.Stores.Find(StoreId);
            List<ProductEntity> productsByStore = store.Products;
            return productsByStore;
        }

        public ProductResponse AddProductForStore(Guid StoreId, Product Product)
        {

            var store = _dbContext.Stores.Find(StoreId);
            var newProduct = new ProductEntity()
            {
                Price = Product.Price,
                Description = Product.Description,
                ProductName = Product.ProductName
            };

            store.Products.Add(newProduct);
            _dbContext.SaveChanges();

            var productResponse = new ProductResponse()
            {
                ProductName = newProduct.ProductName,
                Description = newProduct.Description,
                Price = newProduct.Price,
            };

            return productResponse;
        }
    }
}
