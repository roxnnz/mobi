namespace mobi_api.Dtos
{
    public record ProductDto
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }
}
