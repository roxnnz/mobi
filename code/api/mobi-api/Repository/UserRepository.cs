using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;

namespace mobi_api.Repository
{
    public interface IUserRepository
    {
        List<UserEntity> GetAllUsers();
        UserEntity GetUserByFirstName(String FirstName);
        UserEntity GetUserByUserId(Guid StoreId);
    }

    public class UserRepository : IUserRepository
    {

        private readonly MobiConsumerContext _dbContext;

        public UserRepository()
        {

        }
        
        public UserRepository(MobiConsumerContext mobiConsumerContext)
        {
            _dbContext = mobiConsumerContext;
        }
        public List<UserEntity> GetAllUsers()
        {
            return this.GetAllUsersFromDB();
        }

        private List<UserEntity> GetAllUsersFromDB()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserEntity? GetUserByFirstName(string FirstName)
        {
            try
            {
                return _dbContext.Users.Where(User => User.FirstName.Equals(FirstName))
                        .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserEntity? GetUserByUserId(Guid UserId)
        {
            try
            {
                return _dbContext.Users.Where(User => User.UserId.Equals(UserId))
                        .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
