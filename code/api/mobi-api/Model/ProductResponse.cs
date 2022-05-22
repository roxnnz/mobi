namespace mobi_api.Model
{
    public class ProductResponse
    {
        public string ProductName { get; set; } = "No product name found";
        public string Description { get; set; } = "No product description found";
        public double? Price { get; set; }
    }    
}
