using BoardGameVoter.Models.EntityModels.VoteSessions;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public interface IVoteSessionResultRepository
    {
        public List<VoteSessionResult> GetByVoteSessionID(int voteSessionID);
    }
}
