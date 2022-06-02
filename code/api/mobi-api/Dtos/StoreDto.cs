namespace mobi_api.Dtos
{
    public record StoreDto
    {
        public Guid StoreId { get; set; }
        public string? StoreName { get; set; }
        public string? StorePhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
    }
}
