using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGame_BoardGameCategoryRepository : RepositoryBase<BoardGame_BoardGameCategory, BoardGame, RepositoryLoadOptions>, IBoardGame_BoardGameCategoryRepository
    {
        public BoardGame_BoardGameCategoryRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
