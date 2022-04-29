using System.ComponentModel.DataAnnotations;

namespace mobi_api.DAO
{
    public class StoreEntity
    {
        [Key]
        public Guid StoreId { get; set; }
        public string? StoreName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public List<ProductEntity>? Products { get; set; } = new List<ProductEntity>();
    }
}
