using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys
{
    public interface IBoardGameRepository : IRepositoryBase<BoardGame>
    {
        public List<BoardGame> GetByTitle(string title);
    }
}
