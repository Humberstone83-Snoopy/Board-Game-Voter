using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDBContextService dbContextService) 
            : base(dbContextService)
        {
        }

        public User GetByEmail(string email)
        {
            return Data.FirstOrDefault(user => user.EmailAddress == email);
        }
    }
}
