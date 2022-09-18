using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class VoteRepository : RepositoryBase<Vote>, IVoteRepository
    {
        public VoteRepository(VoteDBContext dbContext) : base(dbContext)
        {
        }

        public List<Vote> GetByVoteSessionID(int voteSessionID)
        {
            return DBContext.Data.Where(vote => vote.VoteSessionID == voteSessionID).ToList();
        }
    }
}