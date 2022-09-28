using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionResultRepository : RepositoryBase<VoteSessionResult, VoteSession, VoteSessionResultLoadOptions>, IVoteSessionResultRepository
    {
        public VoteSessionResultRepository(IDBContextService dbContextService)
            : this(dbContextService, new())
        {
        }

        public VoteSessionResultRepository(IDBContextService dbContextService, VoteSessionResultLoadOptions loadOptions)
            : base(dbContextService, loadOptions)
        {
        }

        public List<VoteSessionResult> GetByVoteSessionID(int voteSessionID)
        {
            return Data.Where(result => result.VoteSessionID == voteSessionID).ToList();
        }
    }
}
