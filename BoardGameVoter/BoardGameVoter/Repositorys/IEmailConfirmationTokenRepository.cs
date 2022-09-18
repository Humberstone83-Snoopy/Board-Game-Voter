using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Repositorys
{
    public interface IEmailConfirmationTokenRepository : IRepositoryBase<EmailConfirmationToken>
    {
        public EmailConfirmationToken GenerateEmailConfirmationToken(int userID);
    }
}
