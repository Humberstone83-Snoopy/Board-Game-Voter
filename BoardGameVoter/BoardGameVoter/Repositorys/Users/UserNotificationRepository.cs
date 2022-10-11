using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserNotificationRepository : RepositoryBase<UserNotification, User, RepositoryLoadOptions>, IUserNotificationRepository
    {
        public UserNotificationRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }

        public List<UserNotification> GetByUserID(int userID)
        {
            return Data.Where(notification => notification.RecipientUserID == userID).ToList();
        }
    }
}
