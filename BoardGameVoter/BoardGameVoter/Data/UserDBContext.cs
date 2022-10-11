using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels.Users;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class UserDBContext : DBContextBase<User>, IDBContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<UserFriend> FriendData { get; set; }
        public DbSet<UserNotification> NotificationData { get; set; }
        public DbSet<UserPassword> PasswordData { get; set; }
        public DbSet<UserSession> SessionData { get; set; }
    }
}
