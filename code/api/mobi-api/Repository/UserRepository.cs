using mobi_api.Model;
using mobi_api.DAO;
using mobi_api.Services;

namespace mobi_api.Repository
{
    public interface IUserRepository
    {
        List<UserEntity> GetAllUsers();
        UserEntity GetUserByUserId(Guid StoreId);
        UserEntity UpdateUser(Guid UserId, UserEntity UserDetail);
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

        public UserEntity UpdateUser(Guid UserId, UserEntity UserDetail)
        {
            var TargetUser = _dbContext.Users.SingleOrDefault(User => User.UserId.Equals(UserId));
            if (TargetUser == null) return null;
            TargetUser.FirstName = UserDetail.FirstName;
            TargetUser.LastName = UserDetail.LastName;
            TargetUser.Email = UserDetail.Email;
            TargetUser.Phone = UserDetail.Phone;

            _dbContext.SaveChanges();
            return TargetUser;       
        }
    }
}
