namespace mobi_api.Model
{
    // This model is used for return / response product calls
    public class ProductResponse
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }    
}
