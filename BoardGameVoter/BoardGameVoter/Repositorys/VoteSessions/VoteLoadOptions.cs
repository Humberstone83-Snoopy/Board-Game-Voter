using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteLoadOptions : RepositoryLoadOptions
    {
        public bool LoadWithLibrarygame { get; set; } = false;
    }
}
