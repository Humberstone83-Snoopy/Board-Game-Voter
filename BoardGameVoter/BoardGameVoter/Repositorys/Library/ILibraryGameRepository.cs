using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.BoardGames;

namespace BoardGameVoter.Repositorys.Library
{
    public interface ILibraryGameRepository
    {
        public void AddNew(User user, BoardGame boardGame);

        public List<LibraryGame> GetByID(IEnumerable<int> LibraryGameIDs, bool includeBoardGames);
        public List<LibraryGame> GetByUserID(int userID, bool includeBoardGames = false);
        public List<LibraryGame> GetByUserID(IEnumerable<int> userIDs, bool includeBoardGames = false);

    }
}
