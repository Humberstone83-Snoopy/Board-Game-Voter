using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class EmailConfirmationTokenDBContext : DbContextBase<EmailConfirmationToken>
    {
        public EmailConfirmationTokenDBContext(DbContextOptions<EmailConfirmationTokenDBContext> options) : base(options)
        {
        }
    }
}
