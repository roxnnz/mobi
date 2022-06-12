using System.ComponentModel.DataAnnotations;

namespace mobi_api.Dtos
{
    public record CreateStoreDto
    {
        [Required]
        public string? StoreName { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Address { get; set; }

        public string? Website { get; set; }
    }
}
