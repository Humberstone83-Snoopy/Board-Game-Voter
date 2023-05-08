using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameRepository : RepositoryBase<BoardGame, BoardGameLoadOptions>, IBoardGameRepository
    {
        public BoardGameRepository(IBGVServiceProvider bGVServiceProvider)
            : this(bGVServiceProvider, new())
        {
        }

        public BoardGameRepository(IBGVServiceProvider bGVServiceProvider, BoardGameLoadOptions boardGameLoadOptions)
            : base(bGVServiceProvider, boardGameLoadOptions)
        {
        }

        public List<BoardGame> GetByTitle(string title)
        {
            return Data.Where(game => game.Title.StartsWith(title)).ToList();
        }

        public BoardGame GetByBoardGameGeekID(int boardGameGeekID)
        {
            return Data.FirstOrDefault(game => game.BoardGameGeekID == boardGameGeekID);
        }
    }
}