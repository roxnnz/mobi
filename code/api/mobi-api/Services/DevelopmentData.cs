using System.Text.Json;
using mobi_api.Model;

namespace mobi_api.Services
{
    public class DevelopmentData
    {
        public DevelopmentData()
        {

        }

        public void GenereateDevelopmentData()
        {
            try
            {
                using (var stream = new StreamReader("MockData/Users.json"))
                {
                    string jsonStringUser = stream.ReadToEnd();
                    List<User> users = JsonSerializer.Deserialize<List<User>>(jsonStringUser);
                }

                using (var stream = new StreamReader("MockData/Products.json"))
                {
                    string jsonStringProduct = stream.ReadToEnd();
                    List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonStringProduct);
                }

                using (var stream = new StreamReader("MockData/Store.json"))
                {
                    string jsonStringStore = stream.ReadToEnd();
                    List<Store> stores = JsonSerializer.Deserialize<List<Store>>(jsonStringStore);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
