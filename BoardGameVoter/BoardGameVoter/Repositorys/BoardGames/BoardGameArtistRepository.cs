using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameArtistRepository : RepositoryBase<BoardGameArtist, BoardGame, RepositoryLoadOptions>, IBoardGameArtistRepository
    {
        public BoardGameArtistRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
