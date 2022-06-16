using System.ComponentModel.DataAnnotations;

namespace mobi_api.Dtos
{
    public record UpdateStoreDto
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
