using System.ComponentModel.DataAnnotations;

namespace mobi_api.Dtos
{
    //Receive data from request
    public record CreateProductDto
    {
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Range(0.00,1000.00)]
        public double? Price { get; set; }
    }
}