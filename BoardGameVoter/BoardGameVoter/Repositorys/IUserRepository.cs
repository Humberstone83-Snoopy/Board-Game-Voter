using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User GetByEmail(string email);
    }
}