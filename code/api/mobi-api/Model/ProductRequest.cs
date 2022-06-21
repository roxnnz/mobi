namespace mobi_api.Model
{
    // This model is used for product request calls
    public class ProductRequest
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
    }    
}
