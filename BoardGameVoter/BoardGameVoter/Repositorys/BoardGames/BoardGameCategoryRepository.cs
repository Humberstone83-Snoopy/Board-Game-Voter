using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameCategoryRepository : RepositoryBase<BoardGameCategory, BoardGame, RepositoryLoadOptions>, IBoardGameCategoryRepository
    {
        public BoardGameCategoryRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
