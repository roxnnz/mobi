using System.ComponentModel.DataAnnotations;

namespace mobi_api.DAO
{
    public class ProductEntity
    {
        [Key]
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public Guid StoreId { get; set; }
        public StoreEntity StoreEntity { get; set; }
    }
}
