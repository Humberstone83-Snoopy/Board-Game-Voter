using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public interface IBoardGameCategoryRepository : IRepositoryBase<BoardGameCategory, RepositoryLoadOptions>
    {
    }
}
