using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.VoteSessions
{
    public class VoteSessionLoadOptions : RepositoryLoadOptions
    {
        public bool LoadWithAttendees { get; set; }
        public bool LoadWithHostUser { get; set; }
        public bool LoadWithLeadGame { get; set; }
        public bool LoadWithLocation { get; set; }
        public bool LoadWithResults { get; set; }
        public bool LoadWithVotes { get; set; }
    }
}
