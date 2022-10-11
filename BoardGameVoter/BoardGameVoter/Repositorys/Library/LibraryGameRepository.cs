using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Repositorys.Shared;
using BoardGameVoter.Services;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Repositorys.Library
{
    public class LibraryGameRepository : RepositoryBase<LibraryGame, LibraryGameLoadOptions>, ILibraryGameRepository
    {
        private BoardGameRepository __BoardGameRepository;

        public LibraryGameRepository(IBGVServiceProvider bGVServiceProvider)
            : this(bGVServiceProvider, new())
        {
        }

        public LibraryGameRepository(IBGVServiceProvider bGVServiceProvider, LibraryGameLoadOptions loadOptions)
            : base(bGVServiceProvider, loadOptions)
        {

            __BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
        }

        public void AddNew(User user, BoardGame boardGame)
        {
            if (boardGame == null)
            {
                throw new ArgumentNullException(nameof(boardGame));
            }
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (!DoesUserLibraryContainGame(user.ID, boardGame.ID))
            {
                Add(new LibraryGame()
                {
                    BoardGameID = boardGame.ID,
                    IsAvailable = true,
                    Name = boardGame.Title,
                    UserID = user.ID,
                    Votes = 0,
                    UID = Guid.NewGuid()
                });
            }
            else
            {
                throw new ArgumentException($"User library already contains the game {boardGame.Title}");
            }
        }

        private bool DoesUserLibraryContainGame(int userID, int boardGameID)
        {
            return GetByUserID(userID).Any(game => game.BoardGameID == boardGameID);
        }

        public List<LibraryGame> GetByID(IEnumerable<int> LibraryGameIDs, bool includeBoardGames)
        {
            List<LibraryGame> _LibraryGames = Data.Where(entity => LibraryGameIDs.Contains(entity.ID)).ToList();
            if (includeBoardGames && __BoardGameRepository != null)
            {
                _LibraryGames = LoadWithBoardGames(_LibraryGames);
            }
            return _LibraryGames;
        }

        public List<LibraryGame> GetByUserID(int userID, bool includeBoardGames = false)
        {
            List<LibraryGame> _LibraryGames = Data.Where(game => game.UserID == userID).ToList();
            if (includeBoardGames && __BoardGameRepository != null)
            {
                _LibraryGames = LoadWithBoardGames(_LibraryGames);
            }
            return _LibraryGames;
        }

        public List<LibraryGame> GetByUserID(IEnumerable<int> userIDs, bool includeBoardGames = false)
        {
            List<LibraryGame> _LibraryGames = Data.Where(game => userIDs.Contains(game.UserID)).ToList();
            if (includeBoardGames && __BoardGameRepository != null)
            {
                _LibraryGames = LoadWithBoardGames(_LibraryGames);
            }
            return _LibraryGames;
        }

        private List<LibraryGame> LoadWithBoardGames(List<LibraryGame> libraryGames)
        {
            List<BoardGame> _BoardGames = __BoardGameRepository.GetByID(libraryGames.Select(game => game.BoardGameID)).ToList();
            foreach (LibraryGame libraryGame in libraryGames)
            {
                libraryGame.BoardGame = _BoardGames.FirstOrDefault(game => game.ID == libraryGame.BoardGameID);
            }
            return libraryGames;
        }
    }
}
