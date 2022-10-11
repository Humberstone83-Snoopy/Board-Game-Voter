using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserSessionRepository : RepositoryBase<UserSession, User, RepositoryLoadOptions>, IUserSessionRepository
    {
        public UserSessionRepository(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
        }

        public new UserSession GetByUID(Guid uID)
        {
            RemoveExpiredSessions();
            return Data.FirstOrDefault(user => user.UID == uID);
        }

        public UserSession GetByUserID(int userid)
        {
            RemoveExpiredSessions();
            return Data.FirstOrDefault(user => user.UserID == userid);
        }

        public bool IsExpiredSession(UserSession userSession)
        {
            return DateTime.Now > userSession.SessionStartTime.AddHours(1)
                    || DateTime.Now > userSession.LastInteraction.AddMinutes(20);
        }

        private void RemoveExpiredSessions()
        {
            IEnumerable<UserSession> _ExpiredSessions = GetAll().Where(session => IsExpiredSession(session)).AsEnumerable();
            Delete(_ExpiredSessions);
        }
    }
}