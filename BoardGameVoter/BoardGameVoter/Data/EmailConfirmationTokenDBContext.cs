using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class EmailConfirmationTokenDBContext : DBContextBase<EmailConfirmationToken>, IDBContext
    {
        public EmailConfirmationTokenDBContext(DbContextOptions<EmailConfirmationTokenDBContext> options) : base(options)
        {
        }
    }
}
