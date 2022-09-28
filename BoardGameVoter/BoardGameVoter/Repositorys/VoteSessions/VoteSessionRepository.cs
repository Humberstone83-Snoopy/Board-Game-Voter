using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionRepository : RepositoryBase<VoteSession, VoteSessionLoadOptions>, IVoteSessionRepository
    {
        public VoteSessionRepository(IDBContextService dbContextService)
            : this(dbContextService, new())
        {
        }

        public VoteSessionRepository(IDBContextService dbContextService, VoteSessionLoadOptions loadOptions)
            : base(dbContextService, loadOptions)
        {
        }

        public List<VoteSession> GetAllPublicSessions()
        {
            return GetAll().Where(session => session.IsPublic).ToList();
        }
    }
}