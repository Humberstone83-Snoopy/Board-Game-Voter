using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionResultRepository : RepositoryBase<VoteSessionResult, VoteSession, VoteSessionResultLoadOptions>, IVoteSessionResultRepository
    {
        public VoteSessionResultRepository(IBGVServiceProvider bGVServiceProvider)
            : this(bGVServiceProvider, new())
        {
        }

        public VoteSessionResultRepository(IBGVServiceProvider bGVServiceProvider, VoteSessionResultLoadOptions loadOptions)
            : base(bGVServiceProvider, loadOptions)
        {
        }

        public List<VoteSessionResult> GetByVoteSessionID(int voteSessionID)
        {
            return Data.Where(result => result.VoteSessionID == voteSessionID).ToList();
        }
    }
}
