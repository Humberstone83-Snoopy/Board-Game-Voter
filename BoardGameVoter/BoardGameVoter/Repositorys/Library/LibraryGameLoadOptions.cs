using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.Library
{
    public class LibraryGameLoadOptions : RepositoryLoadOptions
    {
        public bool LoadWithBoardGame { get; set; } = false;
        public bool LoadWithUser { get; set; } = false;
    }
}
