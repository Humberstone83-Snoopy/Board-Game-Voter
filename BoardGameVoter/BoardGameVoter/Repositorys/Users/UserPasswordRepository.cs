using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserPasswordRepository : RepositoryBase<UserPassword, User, RepositoryLoadOptions>, IUserPasswordRepository
    {
        public UserPasswordRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }

        public UserPassword GetByUserID(int userID)
        {
            return Data.FirstOrDefault(user => user.UserID == userID);
        }
    }
}
