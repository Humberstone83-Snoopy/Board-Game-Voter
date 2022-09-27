using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.EmailConfirmationTokens
{
    public class EmailConfirmationTokenRepository : RepositoryBase<EmailConfirmationToken>
    {
        public EmailConfirmationTokenRepository(EmailConfirmationTokenDBContext dbContext) 
            : base(dbContext)
        {
        }

        public EmailConfirmationToken GenerateEmailConfirmationToken(int userID)
        {
            RemoveExistingTokens(userID);
            EmailConfirmationToken _ResetToken = new()
            {
                UID = Guid.NewGuid(),
                UserID = userID
            };
            Add(_ResetToken);
            return _ResetToken;
        }

        private void RemoveExistingTokens(int userID)
        {
            List<EmailConfirmationToken> existingTokens = new();
            existingTokens.AddRange(Data.Where(token => token.UserID == userID));
            if (existingTokens.Count > 0)
            {
                Delete(existingTokens);
            }
        }
    }
}
