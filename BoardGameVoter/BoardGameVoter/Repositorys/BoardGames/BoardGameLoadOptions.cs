using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameLoadOptions : RepositoryLoadOptions
    {
        public bool LoadWithType { get; set; } = false;
        public bool LoadWithCatergories { get; set; } = false;
        public bool LoadWithMechanisms { get; set; } = false;
    }
}
