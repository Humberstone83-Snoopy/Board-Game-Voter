using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameImageRepository : RepositoryBase<BoardGameImage, BoardGame, RepositoryLoadOptions>, IBoardGameImageRepository
    {
        public BoardGameImageRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
