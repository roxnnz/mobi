using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;

namespace mobi_api.Repository
{
    public interface IStoreRepository
    {
        List<StoreEntity> GetAllStores();
    }

    public class StoresRepository : IStoreRepository
    {
        private readonly MobiConsumerContext _dbContext;
        public StoresRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;   
        }

        public List<StoreEntity> GetAllStores()
        {
            return this.GetMockStoresFromDB();
        }

        private List<StoreEntity> GetMockStoresFromDB()
        {
            try
            {
                return _dbContext.Stores.ToList();
            }
            catch (IOException ioex)
            {
                throw new Exception(ioex.Message);
            }
        }
    }
}
