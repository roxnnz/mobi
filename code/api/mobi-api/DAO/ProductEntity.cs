using System.ComponentModel.DataAnnotations;

namespace mobi_api.DAO
{
    public class ProductEntity
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = "Example Product Name";

        [Required]
        public string Description { get; set; } = "Example Description";

        [Required, Range(0,1000)]
        public double Price { get; set; }

        [Required]
        public StoreEntity Store { get; set; } = new StoreEntity();
    }
}
