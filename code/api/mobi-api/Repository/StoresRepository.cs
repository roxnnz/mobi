using mobi_api.Model;
using System.Text.Json;

namespace mobi_api.Repository
{
    interface IStoreRepository
    {
        List<Store> GetAllStores();
    }

    public class StoresRepository : IStoreRepository
    {

        public StoresRepository()
        {
            
        }

        public List<Store> GetAllStores()
        {
            return this.GetMockStoresFromJson();
        }

        private List<Store> GetMockStoresFromJson()
        {
            try
            {
                using (var stream = new StreamReader("MockData/Stores.json"))
                {
                    string jsonString = stream.ReadToEnd();
                    List<Store> stores = JsonSerializer.Deserialize<List<Store>>(jsonString);

                    return stores;
                }
            }
            catch (IOException ioex)
            {
                throw new Exception(ioex.Message);
            }
        }
    }
}
