using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameTypeRepository : RepositoryBase<BoardGameType, BoardGame, RepositoryLoadOptions>, IBoardGameTypeRepository
    {
        public BoardGameTypeRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
