using mobi_api.Model;
using System.Text.Json;

namespace mobi_api.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
    }
    public class ProductsRepository : IProductRepository
    {
        public ProductsRepository()
        {

        }

        public List<Product> GetAllProducts()
        {
            return this.GetMockProductFromJson();
        }

        private List<Product> GetMockProductFromJson()
        {
            try
            {
                using(var stream = new StreamReader("MockData/Products.json"))
                {
                    string jsonString = stream.ReadToEnd();
                    List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonString);
                    return products;
                }
            }
            catch (IOException ioex)
            {
                throw new Exception(ioex.Message);
            }
        }
    }
}
