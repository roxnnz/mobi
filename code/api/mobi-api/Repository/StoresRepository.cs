using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;
using mobi_api.Dtos;

namespace mobi_api.Repository
{
    public interface IStoreRepository
    {
        IEnumerable<StoreDto> GetAllStores();
        IQueryable<StoreDto> GetStoreByStoreId(Guid StoreId);
        void CreateStore(StoreEntity newStore);
        StoreResponse UpdateStoreByStoreId(Guid StoreId, StoreRequest storeRequest);
    }

    public class StoresRepository : IStoreRepository
    {

        private readonly MobiConsumerContext _dbContext;

        public StoresRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
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

        public IQueryable<StoreDto> GetStoreByStoreId(Guid StoreId)
        {
            var result = _dbContext.Stores.Where(s => s.StoreId == StoreId);

            if (result == null) return null;

            else
            {
                IQueryable<StoreDto> storeDtos = result.Select(s => s.EStoreDto());
                return storeDtos;
            }
        }

        public void CreateStore(StoreEntity newStore)
        {
            var store = _dbContext.Stores.Add(newStore);
            _dbContext.SaveChanges();
        }

        public StoreResponse? UpdateStoreByStoreId(Guid storeId, StoreRequest storeRequest)
        {
            var store = _dbContext.Stores.FirstOrDefault(x => x.StoreId.Equals(storeId));

            if (store == null) return null;
            if (storeRequest.StoreName != null) store.StoreName = storeRequest.StoreName;

            if (storeRequest.PhoneNumber != null) store.PhoneNumber = storeRequest.PhoneNumber;

            if (storeRequest.Address != null) store.Address = storeRequest.Address;

            if (storeRequest.Website != null) store.Website = storeRequest.Website;

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
