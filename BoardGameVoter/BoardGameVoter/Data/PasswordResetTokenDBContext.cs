using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class PasswordResetTokenDBContext : DbContextBase<PasswordResetToken>
    {
        public PasswordResetTokenDBContext(DbContextOptions<PasswordResetTokenDBContext> options) : base(options)
        {
        }
    }
}
