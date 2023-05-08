using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;

namespace BoardGameVoter.Repositorys.BoardGames
{
    public class BoardGameFamilyRepository : RepositoryBase<BoardGameFamily, BoardGame, RepositoryLoadOptions>, IBoardGameFamilyRepository
    {
        public BoardGameFamilyRepository(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
        }
    }
}
