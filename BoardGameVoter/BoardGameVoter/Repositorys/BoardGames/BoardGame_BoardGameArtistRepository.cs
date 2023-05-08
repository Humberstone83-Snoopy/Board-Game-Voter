using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGame_BoardGameArtistRepository : RepositoryBase<BoardGame_BoardGameArtist, BoardGame, RepositoryLoadOptions>, IBoardGame_BoardGameArtistRepository
    {
        public BoardGame_BoardGameArtistRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
