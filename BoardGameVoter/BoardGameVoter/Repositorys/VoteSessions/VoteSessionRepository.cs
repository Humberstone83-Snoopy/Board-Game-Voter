using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionRepository : RepositoryBase<VoteSession, VoteSessionLoadOptions>, IVoteSessionRepository
    {
        public VoteSessionRepository(VoteSessionDBContext dbContext)
            : base(dbContext)
        {
        }

        public VoteSessionRepository(VoteSessionDBContext dbContext, VoteSessionLoadOptions loadOptions)
            : base(dbContext, loadOptions)
        {
        }

        public List<VoteSession> GetAllPublicSessions()
        {
            return GetAll().Where(session => session.IsPublic).ToList();
        }
    }
}