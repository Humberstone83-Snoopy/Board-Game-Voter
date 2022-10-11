using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserRepository : RepositoryBase<User, UserLoadOptions>, IUserRepository
    {
        public UserRepository(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
        }

        public User GetByEmail(string email)
        {
            return Data.FirstOrDefault(user => user.EmailAddress == email);
        }
    }
}
