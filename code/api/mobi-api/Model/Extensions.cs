using mobi_api.DAO;
using mobi_api.Dtos;

namespace mobi_api.Model
{
    public static class Extensions
    {
        public static ProductDto EProductDto(this ProductEntity productEntity)
        {
            return new ProductDto
            {
                ProductId = productEntity.ProductId,
                ProductName = productEntity.ProductName,
                Description = productEntity.Description,
                Price = productEntity.Price,
            };
        }

        public static StoreDto EStoreDto(this StoreEntity storeEntity)
        {
            return new StoreDto
            {
                StoreId = storeEntity.StoreId,
                StoreName = storeEntity.StoreName,
                StorePhoneNumber = storeEntity.PhoneNumber,
                Address = storeEntity.Address,
                Website = storeEntity.Website,
            };
        }
    }
}
