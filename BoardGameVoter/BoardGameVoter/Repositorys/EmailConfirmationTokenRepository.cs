using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class EmailConfirmationTokenRepository : RepositoryBase<EmailConfirmationToken>
    {
        public EmailConfirmationTokenRepository(EmailConfirmationTokenDBContext dbContext) : base(dbContext)
        {
        }

        public EmailConfirmationToken GenerateEmailConfirmationToken(int userID)
        {
            RemoveExistingTokens(userID);
            EmailConfirmationToken _ResetToken = new EmailConfirmationToken()
            {
                UID = Guid.NewGuid(),
                UserID = userID
            };
            DBContext.Add(_ResetToken);
            DBContext.SaveChanges();
            return _ResetToken;
        }

        private void RemoveExistingTokens(int userID)
        {
            List<EmailConfirmationToken> existingTokens = new List<EmailConfirmationToken>();
            existingTokens.AddRange(DBContext.Data.Where(token => token.UserID == userID));
            if (existingTokens.Count > 0)
            {
                DBContext.RemoveRange(existingTokens);
                DBContext.SaveChanges(true);
            }
        }
    }
}
