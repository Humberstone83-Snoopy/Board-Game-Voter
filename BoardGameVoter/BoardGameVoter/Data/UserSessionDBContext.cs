using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class UserSessionDBContext : DbContextBase<UserSession>
    {
        public UserSessionDBContext(DbContextOptions<UserSessionDBContext> options) : base(options)
        {
        }
    }
}
