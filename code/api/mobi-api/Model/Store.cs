using System.Text.Json.Serialization;
namespace mobi_api.Model
{
    public class Store
    {
        public string StoreName { get; set; } = "No store name found";
        public string PhoneNumber { get; set; } = "No phone number found";
        public string Website { get; set; } = "No website found";
        public string Address { get; set; } = "No address found";
    }
}
