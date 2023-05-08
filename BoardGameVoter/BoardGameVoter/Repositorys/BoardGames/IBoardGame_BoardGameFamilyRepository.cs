using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public interface IBoardGame_BoardGameFamilyRepository : IRepositoryBase<BoardGame_BoardGameFamily, RepositoryLoadOptions>
    {
    }
}
