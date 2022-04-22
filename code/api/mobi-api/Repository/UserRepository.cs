using mobi_api.Model;
using System.Text.Json;

namespace mobi_api.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
    }

    public class UsersRepository : IUserRepository
    {

        public UsersRepository()
        {

        }

        public List<User> GetAllUsers()
        {
            return this.GetMockUsersFromJson();
        }

        private List<User> GetMockUsersFromJson()
        {
            try
            {
                using (var stream = new StreamReader("MockData/Users.json"))
                {
                    string jsonString = stream.ReadToEnd();
                    List<User> users= JsonSerializer.Deserialize<List<User>>(jsonString);

                    return users;
                }
            }
            catch (IOException ioex)
            {
                throw new Exception(ioex.Message);
            }
        }
    }
}
