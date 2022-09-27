using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UserDBContext dbContext) : base(dbContext)
        {
        }

        public User GetByEmail(string email)
        {
            return Data.FirstOrDefault(user => user.EmailAddress == email);
        }
    }
}
