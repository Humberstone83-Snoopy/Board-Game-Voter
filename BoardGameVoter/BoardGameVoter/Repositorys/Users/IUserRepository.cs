using BoardGameVoter.Models.EntityModels.Users;

namespace BoardGameVoter.Repositorys.Users
{
    public interface IUserRepository
    {
        public User GetByEmail(string email);
    }
}