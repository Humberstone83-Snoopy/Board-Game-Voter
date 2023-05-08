using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGame_BoardGameFamilyRepository : RepositoryBase<BoardGame_BoardGameFamily, BoardGame, RepositoryLoadOptions>, IBoardGame_BoardGameFamilyRepository
    {
        public BoardGame_BoardGameFamilyRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
