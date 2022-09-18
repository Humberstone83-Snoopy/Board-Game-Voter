using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IPasswordResetTokenRepository : IRepositoryBase<PasswordResetToken>
    {
        public PasswordResetToken GeneratePasswordResetToken(int userID);
    }
}
