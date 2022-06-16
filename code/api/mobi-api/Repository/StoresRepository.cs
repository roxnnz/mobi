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
        StoreDto UpdateStoreByStoreId(Guid storeId, UpdateStoreDto updateStoreDto);
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

        public StoreDto UpdateStoreByStoreId(Guid storeId, UpdateStoreDto updateStoreDto)
        {
            var exStoreEntity = _dbContext.Stores.Find(storeId);

            if (exStoreEntity == null) return null;

            else
            {
                if (updateStoreDto.StoreName != null) exStoreEntity.StoreName = updateStoreDto.StoreName;

                if (updateStoreDto.PhoneNumber != null) exStoreEntity.PhoneNumber = updateStoreDto.PhoneNumber;

                if (updateStoreDto.Address != null) exStoreEntity.Address = updateStoreDto.Address;

                if (updateStoreDto.Website != null) exStoreEntity.Website = updateStoreDto.Website;

                _dbContext.SaveChanges();

                return exStoreEntity.EStoreDto() with
                {
                    StoreName = exStoreEntity.StoreName,
                    PhoneNumber = exStoreEntity.PhoneNumber,
                    Address = exStoreEntity.Address,
                    Website = exStoreEntity.Website,
                };
            }
        }
    }
}
