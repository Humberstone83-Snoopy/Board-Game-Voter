using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class PasswordResetTokenDBContext : DBContextBase<PasswordResetToken>, IDBContext
    {
        public PasswordResetTokenDBContext(DbContextOptions<PasswordResetTokenDBContext> options) : base(options)
        {
        }
    }
}
