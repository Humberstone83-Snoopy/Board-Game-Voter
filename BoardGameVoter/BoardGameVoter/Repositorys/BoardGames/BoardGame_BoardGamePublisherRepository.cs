using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGame_BoardGamePublisherRepository : RepositoryBase<BoardGame_BoardGamePublisher, BoardGame, RepositoryLoadOptions>, IBoardGame_BoardGamePublisherRepository
    {
        public BoardGame_BoardGamePublisherRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
