using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public class BoardGameRepository : RepositoryBase<BoardGame>, IBoardGameRepository
    {
        public BoardGameRepository(BoardGameDBContext dbContext) : base(dbContext)
        {
        }

        public List<BoardGame> GetByTitle(string title)
        {
            return DBContext.Data.Where(game => game.Title.StartsWith(title)).ToList();
        }
    }
}