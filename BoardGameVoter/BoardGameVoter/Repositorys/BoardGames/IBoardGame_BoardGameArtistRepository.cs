using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public interface IBoardGame_BoardGameArtistRepository : IRepositoryBase<BoardGame_BoardGameArtist, RepositoryLoadOptions>
    {
    }
}
