using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameRepository : RepositoryBase<BoardGame, BoardGameLoadOptions>, IBoardGameRepository
    {
        public BoardGameRepository(IDBContextService dbContextService)
            : this(dbContextService, new())
        {
        }

        public BoardGameRepository(IDBContextService dbContextService, BoardGameLoadOptions boardGameLoadOptions)
            : base(dbContextService, boardGameLoadOptions)
        {
        }

        public List<BoardGame> GetByTitle(string title)
        {
            return Data.Where(game => game.Title.StartsWith(title)).ToList();
        }
    }
}