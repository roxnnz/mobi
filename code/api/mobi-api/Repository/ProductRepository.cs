using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;
using System.Text.Json;


namespace mobi_api.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        List<ProductEntity> GetProductByStoreId(Guid StoreId);
    }
    public class ProductsRepository : IProductRepository
    {
        private readonly MobiConsumerContext _dbContext;
        public ProductsRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
        }

        public List<Product> GetAllProducts()
        {
            return this.GetMockProductFromJson();
        }

        public List<ProductEntity> GetProductByStoreId(Guid StoreId)
        {
            var store = _dbContext.Stores.Find(StoreId);
            List<ProductEntity> productsByStore = store.Products;
            return productsByStore;
        }

        private List<Product> GetMockProductFromJson()
        {
            try
            {
                using(var stream = new StreamReader("MockData/Products.json"))
                {
                    string jsonString = stream.ReadToEnd();
                    List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonString);
                    return products;
                }
            }
            catch (IOException ioex)
            {
                throw new Exception(ioex.Message);
            }
        }
    }
}
