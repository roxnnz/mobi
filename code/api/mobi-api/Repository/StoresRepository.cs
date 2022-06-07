using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;
using mobi_api.Dtos;

namespace mobi_api.Repository
{
    public interface IStoreRepository
    {
        IEnumerable<StoreDto> GetAllStores();
        StoreEntity GetStoreByStoreId(Guid StoreId);
        StoreResponse CreateStore(StoreRequest StoreRequset);
        StoreResponse UpdateStoreByStoreId(Guid StoreId, StoreRequest storeRequest);
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

        public IEnumerable<StoreDto> GetAllStores()
        {
            return _dbContext.Stores.Select(stores => stores.EStoreDto());
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

        public StoreResponse? UpdateStoreByStoreId(Guid storeId, StoreRequest storeRequest)
        {
            var store = _dbContext.Stores.FirstOrDefault(x => x.StoreId.Equals(storeId));
            if (store == null) 
                return null;
            if(storeRequest.StoreName != null)             
                store.StoreName = storeRequest.StoreName;           
            
            if(storeRequest.PhoneNumber != null)            
                store.PhoneNumber = storeRequest.PhoneNumber;            

            if(storeRequest.Address != null)            
                store.Address = storeRequest.Address;            
                
            if(storeRequest.Website != null)
                store.Website = storeRequest.Website;                        
            
            _dbContext.SaveChanges();
             
            return new StoreResponse()
            {
                StoreName = store.StoreName,
                PhoneNumber = store.PhoneNumber,
                Address = store.Address,
                Website = store.Website,
            };
        }
    }
}
