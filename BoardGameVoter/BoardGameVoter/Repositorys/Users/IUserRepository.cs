using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Repositorys.Users
{
    public interface IUserRepository
    {
        public User GetByEmail(string email);
    }
}