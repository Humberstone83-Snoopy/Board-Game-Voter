using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.UserLibrarys
{
    public class UserLibraryManager : IUserLibraryManager
    {
        private readonly LibraryGameRepository __LibraryGameRepository;

        public UserLibraryManager(IDBContextService dbContextService)
        {
            __LibraryGameRepository = new LibraryGameRepository(dbContextService);
        }

        public List<UserLibraryTableModel> GetUserLibrary(int userID)
        {
            List<LibraryGame> _LibraryGameData = __LibraryGameRepository.GetByUserID(userID, true);
            return UserLibraryTableModelAdapter.Convert(_LibraryGameData);
        }
    }
}
