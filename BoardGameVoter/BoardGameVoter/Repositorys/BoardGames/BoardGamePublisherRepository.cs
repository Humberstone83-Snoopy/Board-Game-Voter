using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGamePublisherRepository : RepositoryBase<BoardGamePublisher, BoardGame, RepositoryLoadOptions>, IBoardGamePublisherRepository
    {
        public BoardGamePublisherRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
