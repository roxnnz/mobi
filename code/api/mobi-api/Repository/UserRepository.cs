using mobi_api.Model;
using System.Text.Json;

namespace mobi_api.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserByFirstName(string FirstName);
    }

    public class UsersRepository : IUserRepository
    {

        public UsersRepository()
        {

        }
        public User GetUserByFirstName(string FirstName)
        {
            try
            {
                using (var stream = new StreamReader("MockData/Users.json"))
                {
                    string jsonString = stream.ReadToEnd();
                    List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);
                    return users.Find(user => user.FirstName == FirstName);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
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
