namespace mobi_api.DAO
{
    public class ProductEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }

        public double? Price { get; set; }

        public double? fee { get; set; }
    }
}
