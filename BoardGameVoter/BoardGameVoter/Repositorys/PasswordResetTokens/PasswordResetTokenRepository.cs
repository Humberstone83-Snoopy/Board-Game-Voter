using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.PasswordResetTokens
{
    public class PasswordResetTokenRepository : RepositoryBase<PasswordResetToken>, IPasswordResetTokenRepository
    {
        public PasswordResetTokenRepository(IDBContextService dbContextService) 
            : base(dbContextService)
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
            Add(_ResetToken);
            return _ResetToken;
        }

        private void RemoveExistingTokens(int userID)
        {
            List<PasswordResetToken> existingTokens = new List<PasswordResetToken>();
            existingTokens.AddRange(Data.Where(token => token.UserID == userID));
            if (existingTokens.Count > 0)
            {
                Delete(existingTokens);
            }
        }
    }
}
