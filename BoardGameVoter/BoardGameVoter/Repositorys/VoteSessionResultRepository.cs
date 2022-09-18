using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class VoteSessionResultRepository : RepositoryBase<VoteSessionResult>, IVoteSessionResultRepository
    {
        public VoteSessionResultRepository(DbContextBase<VoteSessionResult> dbContext) : base(dbContext)
        {
        }

        public List<VoteSessionResult> GetByVoteSessionID(int voteSessionID)
        {
            return DBContext.Data.Where(result => result.VoteSessionID == voteSessionID).ToList();
        }
    }
}
