using mobi_api.Model;
using System.Text.Json;
using mobi_api.Services;
using mobi_api.DAO;

namespace mobi_api.Repository
{
    public interface IUserRepository
    {
        List<UsersEntity> GetAllUsers();
        UsersEntity GetUserByFirstName(string FirstName);
        bool IsUserExists(string Email);
        void InitUser(string Email);
        UsersEntity UpdateUserByUserId(Guid UserId, UpdateUserRequest User);
    }

    public class UsersRepository : IUserRepository
    {
        private readonly MobiConsumerContext _dbContext;

        public UsersRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
        }

        public UsersEntity UpdateUserByUserId(Guid UserId, UpdateUserRequest User)
        {

            var _user = _dbContext.Users.SingleOrDefault(x => x.UserId.Equals(UserId));
            
            if (_user != null)
            {
                _user.Name = User.Name;
                _dbContext.SaveChanges();
            }

            return _user;
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

        public UsersEntity GetUserByFirstName(string FirstName)
        {
            return new UsersEntity();
        }
        public List<UsersEntity> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
