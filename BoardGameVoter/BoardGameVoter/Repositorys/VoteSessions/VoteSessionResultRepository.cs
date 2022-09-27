using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionResultRepository : RepositoryBase<VoteSessionResult, VoteSession, VoteSessionResultLoadOptions>, IVoteSessionResultRepository
    {
        public VoteSessionResultRepository(VoteSessionDBContext dbContext)
            : base(dbContext)
        {
        }

        public VoteSessionResultRepository(VoteSessionDBContext dbContext, VoteSessionResultLoadOptions loadOptions)
            : base(dbContext, loadOptions)
        {
        }

        public List<VoteSessionResult> GetByVoteSessionID(int voteSessionID)
        {
            return Data.Where(result => result.VoteSessionID == voteSessionID).ToList();
        }
    }
}
