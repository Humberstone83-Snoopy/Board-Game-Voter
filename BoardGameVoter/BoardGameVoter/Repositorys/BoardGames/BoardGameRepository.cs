using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameRepository : RepositoryBase<BoardGame, BoardGameLoadOptions>, IBoardGameRepository
    {
        public BoardGameRepository(BoardGameDBContext dbContext) 
            : base(dbContext)
        {
        }

        public BoardGameRepository(BoardGameDBContext dbContext, BoardGameLoadOptions boardGameLoadOptions) 
            : base(dbContext, boardGameLoadOptions)
        {
        }

        public List<BoardGame> GetByTitle(string title)
        {
            return Data.Where(game => game.Title.StartsWith(title)).ToList();
        }
    }
}