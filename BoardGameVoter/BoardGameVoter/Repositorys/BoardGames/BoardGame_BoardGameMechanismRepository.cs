using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGame_BoardGameMechanismRepository : RepositoryBase<BoardGame_BoardGameMechanism, BoardGame, RepositoryLoadOptions>, IBoardGame_BoardGameMechanismRepository
    {
        public BoardGame_BoardGameMechanismRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
