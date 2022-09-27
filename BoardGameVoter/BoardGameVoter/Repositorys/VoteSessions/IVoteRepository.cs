using BoardGameVoter.Models.EntityModels.VoteSessions;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public interface IVoteRepository
    {
        public List<Vote> GetByVoteSessionID(int voteSessionID);
    }
}
