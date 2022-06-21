using System.ComponentModel.DataAnnotations;

namespace mobi_api.Dtos
{
    public record ProductDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = "Example Product Name";

        [Required]
        public string Description { get; set; } = "Example Description";

        [Required, Range(0, 1000)]
        public double Price { get; set; }
    }
}
