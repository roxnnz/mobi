using System.Text.Json;
using mobi_api.DAO;
using mobi_api.Model;

namespace mobi_api.Services
{
    public interface IDevelopmentData
    {
        List<StoreEntity> GenerateDevelopmentDataProducts();
        List<StoreEntity> GenerateDevelopmentDataStores();
    }
    public class DevelopmentData : IDevelopmentData
    {
        public DevelopmentData()
        {

        }

        public List<StoreEntity> GenerateDevelopmentDataProducts()
        {
            try
            {
                using (var stream = new StreamReader("MockData/Products.json"))
                {
                    string jsonStringProducts = stream.ReadToEnd();
                    List<ProductEntity> products = JsonSerializer.Deserialize<List<ProductEntity>>(jsonStringProducts);

                    using (var db = new MobiConsumerContext())
                    {
                        var stores = db.Stores.ToList();

                        stores.ForEach(store =>
                        {
                            products.ForEach(product =>
                            {
                                store.Products.Add(new ProductEntity { ProductName = product.ProductName, Description = product.Description, Price = product.Price, StoreId = store.StoreId });
                            });

                        });

                        db.SaveChanges();

                        var storess = db.Stores.ToList();

                        return storess;
                    }
                }
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
                using (var stream = new StreamReader("MockData/Stores.json"))
                {
                    string jsonStringStore = stream.ReadToEnd();
                    List<StoreEntity> stores = JsonSerializer.Deserialize<List<StoreEntity>>(jsonStringStore);

                    using (var db = new MobiConsumerContext())
                    {
                        stores.ForEach(s =>
                        {
                            db.Add(new StoreEntity() { StoreName = s.StoreName, PhoneNumber = s.PhoneNumber, Address = s.Address, Website = s.Website});
                        });

                        db.SaveChanges();

                        var savedStores = db.Stores.ToList();
                        return savedStores;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
