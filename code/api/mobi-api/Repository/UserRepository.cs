using mobi_api.Model;
using System.Text.Json;
using mobi_api.Services;
using mobi_api.DAO;

namespace mobi_api.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserByFirstName(string FirstName);
        bool IsUserExists(string Email);

        void InitUser(string Email);
    }

    public class UsersRepository : IUserRepository
    {
        private readonly MobiConsumerContext _dbContext;

        public UsersRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
        }

        public void InitUser(string Email)
        {
            var user = new UsersEntity()
            {
                Name = "",
                Email = Email,
                Created = DateTime.Now,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public bool IsUserExists(string Email)
        {
           return _dbContext.Users.Where(u => u.Email.Equals(Email)).Any();
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
