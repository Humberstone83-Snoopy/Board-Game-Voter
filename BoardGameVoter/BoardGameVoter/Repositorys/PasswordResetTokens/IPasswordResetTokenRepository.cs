using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Repositorys.PasswordResetTokens
{
    public interface IPasswordResetTokenRepository
    {
        public PasswordResetToken GeneratePasswordResetToken(int userID);
    }
}
