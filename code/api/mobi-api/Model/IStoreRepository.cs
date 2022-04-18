namespace mobi_api.Model
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAllStores();
    }
}