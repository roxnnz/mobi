using mobi_api.Model;

namespace mobi_api.Repository
{
    
    public class StoresRepository : IStoreRepository
    {

        public StoresRepository()
        {
            
        }

        public IEnumerable<Store> GetAllStores()
        {
            return this.GetMockStoresFromJson();
        }

        private IEnumerable<Store> GetMockStoresFromJson()
        {
            // deserialize json
            var store = new Store()
            {
                StoreName = "Jimmy Mobi",
                Website = "www.httpasdf.com",
                PhoneNumber = "1234",
                Address = "asdf"
            };
            return new Store[] { store };
        }
    }
}
