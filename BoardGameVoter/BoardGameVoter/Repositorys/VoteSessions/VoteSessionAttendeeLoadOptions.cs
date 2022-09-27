using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionAttendeeLoadOptions : RepositoryLoadOptions
    {
        public bool LoadWithLibraryGames { get; set; }
        public bool LoadWithUser { get; set; }
    }
}
