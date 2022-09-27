using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionResultLoadOptions : RepositoryLoadOptions
    {
        public bool LoadWithLibraryGame { get; set; }
    }
}
