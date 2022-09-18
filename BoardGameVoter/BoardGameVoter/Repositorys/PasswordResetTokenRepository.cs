using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class PasswordResetTokenRepository : RepositoryBase<PasswordResetToken>, IPasswordResetTokenRepository
    {
        public PasswordResetTokenRepository(PasswordResetTokenDBContext dbContext) : base(dbContext)
        {
        }

        public PasswordResetToken GeneratePasswordResetToken(int userID)
        {
            //Find and remove old tokens first
            RemoveExistingTokens(userID);
            PasswordResetToken _ResetToken = new PasswordResetToken()
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
            List<PasswordResetToken> existingTokens = new List<PasswordResetToken>();
            existingTokens.AddRange(DBContext.Data.Where(token => token.UserID == userID));
            if (existingTokens.Count > 0)
            {
                DBContext.RemoveRange(existingTokens);
                DBContext.SaveChanges(true);
            }
        }
    }
}
