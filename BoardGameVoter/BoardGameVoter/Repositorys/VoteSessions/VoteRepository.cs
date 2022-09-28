using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels.VoteSessions;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteRepository : RepositoryBase<Vote, VoteSession, VoteLoadOptions>, IVoteRepository
    {
        public VoteRepository(IDBContextService dbContextService)
            : this(dbContextService, new())
        {
        }

        public VoteRepository(IDBContextService dbContextService, VoteLoadOptions voteLoadOptions)
            : base(dbContextService, voteLoadOptions)
        {
        }

        public List<Vote> GetByVoteSessionID(int voteSessionID)
        {
            return Data.Where(vote => vote.VoteSessionID == voteSessionID).ToList();
        }
    }
}