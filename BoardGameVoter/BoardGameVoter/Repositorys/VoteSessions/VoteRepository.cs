using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteRepository : RepositoryBase<Vote, VoteSession, VoteLoadOptions>, IVoteRepository
    {
        public VoteRepository(VoteSessionDBContext dbContext)
            : base(dbContext)
        {
        }

        public VoteRepository(VoteSessionDBContext dbContext, VoteLoadOptions voteLoadOptions)
            : base(dbContext, voteLoadOptions)
        {
        }

        public List<Vote> GetByVoteSessionID(int voteSessionID)
        {
            return Data.Where(vote => vote.VoteSessionID == voteSessionID).ToList();
        }
    }
}