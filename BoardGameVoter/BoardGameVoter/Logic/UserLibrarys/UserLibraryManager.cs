using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys.Library;

namespace BoardGameVoter.Logic.UserLibrarys
{
    public class UserLibraryManager : IUserLibraryManager
    {
        private readonly LibraryGameRepository __LibraryGameRepository;

        public UserLibraryManager(LibraryGameDBContext libraryGameDbContext, BoardGameDBContext boardGameDBContext)
        {
            __LibraryGameRepository = new LibraryGameRepository(libraryGameDbContext, boardGameDBContext);
        }

        public List<UserLibraryTableModel> GetUserLibrary(int userID)
        {
            List<LibraryGame> _LibraryGameData = __LibraryGameRepository.GetByUserID(userID, true);
            return UserLibraryTableModelAdapter.Convert(_LibraryGameData);
        }
    }
}
