using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteRepository : RepositoryBase<Vote, VoteSession, VoteLoadOptions>, IVoteRepository
    {
        public VoteRepository(IBGVServiceProvider bGVServiceProvider)
            : this(bGVServiceProvider, new())
        {
        }

        public VoteRepository(IBGVServiceProvider bGVServiceProvider, VoteLoadOptions voteLoadOptions)
            : base(bGVServiceProvider, voteLoadOptions)
        {
        }

        public List<Vote> GetByVoteSessionID(int voteSessionID)
        {
            return Data.Where(vote => vote.VoteSessionID == voteSessionID).ToList();
        }
    }
}