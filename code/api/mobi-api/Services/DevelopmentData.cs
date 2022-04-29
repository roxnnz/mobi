using System.Text.Json;
using mobi_api.DAO;
using mobi_api.Model;

namespace mobi_api.Services
{
    public interface IDevelopmentData
    {
        List<StoreEntity> GenereateDevelopmentData();
    }
    public class DevelopmentData : IDevelopmentData
    {
        public DevelopmentData()
        {

        }

        public List<StoreEntity> GenereateDevelopmentData()
        {
            try
            {
                using (var stream = new StreamReader("MockData/Stores.json"))
                {
                    string jsonStringStore = stream.ReadToEnd();
                    List<Store> stores = JsonSerializer.Deserialize<List<Store>>(jsonStringStore);

                    using (var db = new MobiConsumerContext())
                    {
                        stores.ForEach(s =>
                        {
                            db.Add(new StoreEntity() { StoreName = s.StoreName, PhoneNumber = s.PhoneNumber, Address = s.Address, WebSite = s.Website });
                        });

                        db.SaveChanges();

                        var products = db.Stores.ToList();
                        return products;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return null;
            }
        }
    }
}
