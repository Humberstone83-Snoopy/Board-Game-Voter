using BoardGameVoter.Logic.Shared;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys.Library;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.UserLibrarys
{
    public class UserLibraryManager : BusinessBase, IUserLibraryManager
    {
        private readonly LibraryGameRepository __LibraryGameRepository;

        public UserLibraryManager(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __LibraryGameRepository = new LibraryGameRepository(bGVServiceProvider);
        }

        public List<UserLibraryTableModel> GetUserLibrary(int userID)
        {
            List<LibraryGame> _LibraryGameData = __LibraryGameRepository.GetByUserID(userID, true);
            return UserLibraryTableModelAdapter.Convert(_LibraryGameData);
        }
    }
}
