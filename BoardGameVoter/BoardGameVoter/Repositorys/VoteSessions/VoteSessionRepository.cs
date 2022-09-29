using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionRepository : RepositoryBase<VoteSession, VoteSessionLoadOptions>, IVoteSessionRepository
    {
        public VoteSessionRepository(IBGVServiceProvider bGVServiceProvider)
            : this(bGVServiceProvider, new())
        {
        }

        public VoteSessionRepository(IBGVServiceProvider bGVServiceProvider, VoteSessionLoadOptions loadOptions)
            : base(bGVServiceProvider, loadOptions)
        {
        }

        public List<VoteSession> GetAllPublicSessions()
        {
            return GetAll().Where(session => session.IsPublic).ToList();
        }
    }
}