namespace mobi_api.Model
{
    // Product base model used for import json mock data, keep it for now.
    public class Product
    {
        public string ProductName { get; set; } = "No product name found";
        public string Description { get; set; } = "No product description found";
        public double? Price { get; set; }
    }    
}
