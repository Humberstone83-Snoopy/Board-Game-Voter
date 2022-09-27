using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Repositorys.EmailConfirmationTokens
{
    public interface IEmailConfirmationTokenRepository
    {
        public EmailConfirmationToken GenerateEmailConfirmationToken(int userID);
    }
}
