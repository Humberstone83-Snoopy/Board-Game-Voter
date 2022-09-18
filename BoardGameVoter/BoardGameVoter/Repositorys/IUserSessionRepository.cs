using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IUserSessionRepository : IRepositoryBase<UserSession>
    {
        public new UserSession GetByUID(Guid sessionUID);

        public UserSession GetByUserID(int userid);

        public bool IsExpiredSession(UserSession userSession);
    }
}

