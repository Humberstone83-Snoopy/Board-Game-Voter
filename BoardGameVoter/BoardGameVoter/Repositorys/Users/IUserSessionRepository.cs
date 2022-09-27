using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Repositorys.Users
{
    public interface IUserSessionRepository
    {
        public new UserSession GetByUID(Guid sessionUID);

        public UserSession GetByUserID(int userid);

        public bool IsExpiredSession(UserSession userSession);
    }
}

