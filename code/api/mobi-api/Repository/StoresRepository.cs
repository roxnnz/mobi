using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;

namespace mobi_api.Repository
{
    public interface IStoreRepository
    {
        List<StoreEntity> GetAllStores();
        StoreEntity GetStoreByStoreId(Guid StoreId);
        StoreResponse CreateStore(StoreRequest StoreRequset);
    }

    public class StoresRepository : IStoreRepository
    {

        private readonly MobiConsumerContext _dbContext;
        
        public StoresRepository(MobiConsumerContext mobiConsumerContext) 
        {
            _dbContext = mobiConsumerContext;
        }

        public StoreResponse CreateStore(StoreRequest StoreRequset)
        {
            var newStore = new StoreEntity();

            newStore.Address = StoreRequset.Address;
            newStore.PhoneNumber = StoreRequset.PhoneNumber;
            newStore.StoreName = StoreRequset.StoreName;
            newStore.Website = StoreRequset.Website;

            _dbContext.Stores.Add(newStore);
            _dbContext.SaveChanges();

            return new StoreResponse()
            {
                StoreName = newStore.StoreName,
                Website = newStore.Website,
                Address = newStore.Address,
                PhoneNumber = newStore.PhoneNumber,
            };
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public StoreEntity? GetStoreByStoreId(Guid StoreId)
        {
            try
            {
                return _dbContext.Stores.Where(Store => Store.StoreId.Equals(StoreId))
                        .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
