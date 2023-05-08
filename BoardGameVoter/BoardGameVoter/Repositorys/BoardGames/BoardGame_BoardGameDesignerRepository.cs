using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGame_BoardGameDesignerRepository : RepositoryBase<BoardGame_BoardGameDesigner, BoardGame, RepositoryLoadOptions>, IBoardGame_BoardGameDesignerRepository
    {
        public BoardGame_BoardGameDesignerRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
