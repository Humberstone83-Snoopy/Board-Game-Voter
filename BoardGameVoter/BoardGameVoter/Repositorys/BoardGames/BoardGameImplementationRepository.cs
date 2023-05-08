using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameImplementationRepository : RepositoryBase<BoardGameImplementation, BoardGame, RepositoryLoadOptions>, IBoardGameImplementationRepository
    {
        public BoardGameImplementationRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
