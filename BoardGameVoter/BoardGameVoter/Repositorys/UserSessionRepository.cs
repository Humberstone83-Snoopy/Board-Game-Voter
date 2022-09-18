using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class UserSessionRepository : RepositoryBase<UserSession>, IUserSessionRepository
    {
        public UserSessionRepository(UserSessionDBContext dbContext) : base(dbContext)
        {
        }

        public new UserSession GetByUID(Guid uID)
        {
            RemoveExpiredSessions();
            return DBContext.Data.FirstOrDefault(user => user.UID == uID);
        }

        public UserSession GetByUserID(int userid)
        {
            RemoveExpiredSessions();
            return DBContext.Data.FirstOrDefault(user => user.UserID == userid);
        }

        public bool IsExpiredSession(UserSession userSession)
        {
            return DateTime.Now > userSession.SessionStartTime.AddHours(1)
                    || DateTime.Now > userSession.LastInteraction.AddMinutes(20);
        }

        private void RemoveExpiredSessions()
        {
            // Total Length of a single session || LongPeriod Inactivity
            IEnumerable<UserSession> _ExpiredSessions = GetAll().Where(session => IsExpiredSession(session)).AsEnumerable();
            DBContext.RemoveRange(_ExpiredSessions);
            DBContext.SaveChanges();
        }
    }
}