using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameDesignerRepository : RepositoryBase<BoardGameDesigner, BoardGame, RepositoryLoadOptions>, IBoardGameDesignerRepository
    {
        public BoardGameDesignerRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
