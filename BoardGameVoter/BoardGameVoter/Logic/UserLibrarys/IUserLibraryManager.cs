using BoardGameVoter.Models.TableModels;

namespace BoardGameVoter.Logic.UserLibrarys
{
    public interface IUserLibraryManager
    {
        public List<UserLibraryTableModel> GetUserLibrary(int userID);
    }
}
