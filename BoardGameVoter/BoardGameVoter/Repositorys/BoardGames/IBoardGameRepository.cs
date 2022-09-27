using BoardGameVoter.Models.EntityModels.BoardGames;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public interface IBoardGameRepository
    {
        public List<BoardGame> GetByTitle(string title);
    }
}
