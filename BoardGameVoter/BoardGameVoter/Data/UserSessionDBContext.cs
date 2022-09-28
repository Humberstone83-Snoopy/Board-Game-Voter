using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class UserSessionDBContext : DBContextBase<UserSession>, IDBContext
    {
        public UserSessionDBContext(DbContextOptions<UserSessionDBContext> options) : base(options)
        {
        }
    }
}
