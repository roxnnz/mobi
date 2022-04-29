using System.Text.Json;
using mobi_api.DAO;

namespace mobi_api.Services
{
    public interface IDevelopmentData
    {
        bool CleanDevelopmentData();
        List<StoreEntity> GenerateDevelopmentDataProducts();
        List<StoreEntity> GenerateDevelopmentDataStores();
    }

    public class DevelopmentData : IDevelopmentData
    {
        public readonly MobiConsumerContext _dbContext;
        public DevelopmentData(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
        }

        public bool CleanDevelopmentData()
        {
            try
            {
                _dbContext.Stores.RemoveRange(_dbContext.Stores);
                _dbContext.Products.RemoveRange(_dbContext.Products);
                _dbContext.SaveChanges();

                return true;
            } catch (Exception ex)
            {
                return false;
            }
            
        }

        public List<StoreEntity> GenerateDevelopmentDataProducts()
        {
            try
            {
                var stream = new StreamReader("MockData/Products.json");
                string jsonStringProducts = stream.ReadToEnd();
                List<ProductEntity> products = JsonSerializer.Deserialize<List<ProductEntity>>(jsonStringProducts);
               

                var stores = _dbContext.Stores.ToList();

                stores.ForEach(store =>
                {
                    products.ForEach(product =>
                    {
                        store.Products.Add(new ProductEntity { ProductName = product.ProductName, Description = product.Description, Price = product.Price, StoreId = store.StoreId });
                    });

                });

                _dbContext.SaveChanges();

                var storess = _dbContext.Stores.ToList();

                return storess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<StoreEntity> GenerateDevelopmentDataStores()
        {
            try
            {
                var stream = new StreamReader("MockData/Stores.json");
                string jsonStringStores = stream.ReadToEnd();

                List<StoreEntity> stores = JsonSerializer.Deserialize<List<StoreEntity>>(jsonStringStores);

                stores.ForEach(s =>
                {
                    _dbContext.Add(new StoreEntity() { StoreName = s.StoreName, 
                        PhoneNumber = s.PhoneNumber, 
                        Address = s.Address, 
                        Website = s.Website });
                });

                _dbContext.SaveChanges();

                var savedStores = _dbContext.Stores.ToList();
                return savedStores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
