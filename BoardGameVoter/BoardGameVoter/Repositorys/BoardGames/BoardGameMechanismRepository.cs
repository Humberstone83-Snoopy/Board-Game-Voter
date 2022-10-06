using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameMechanismRepository : RepositoryBase<BoardGameMechanism, BoardGame, RepositoryLoadOptions>, IBoardGameMechanismRepository
    {
        public BoardGameMechanismRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
