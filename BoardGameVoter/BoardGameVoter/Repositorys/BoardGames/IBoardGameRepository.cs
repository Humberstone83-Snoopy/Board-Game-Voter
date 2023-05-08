using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public interface IBoardGameRepository : IRepositoryBase<BoardGame, BoardGameLoadOptions>
    {
        public List<BoardGame> GetByTitle(string title);
    }
}
