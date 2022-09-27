using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys;

namespace BoardGameVoter.Logic.UserLibrarys
{
    public class UserLibraryTableModelAdapter
    {
        internal static List<UserLibraryTableModel> Convert(List<LibraryGame> libraryGames)
        {
            List<UserLibraryTableModel> _UserLibraryReturnModels = new();
            foreach (LibraryGame libraryGame in libraryGames)
            {
                if (libraryGame.BoardGame != null)
                {
                    _UserLibraryReturnModels.Add(new UserLibraryTableModel()
                    {
                        ID = libraryGame.ID,
                        IsAvailable = libraryGame.IsAvailable,
                        Title = libraryGame.Name,
                        Description = libraryGame.BoardGame.Description_Short,
                        Publisher = libraryGame.BoardGame.Publisher,
                        Players = $"{libraryGame.BoardGame.MinimumPlayers}-{libraryGame.BoardGame.MaximumPlayers}",
                        Playtime = $"{libraryGame.BoardGame.MinimumPlayTime}-{libraryGame.BoardGame.MaximumPlayTime} mins",
                        UID = libraryGame.UID
                    });
                }
            }
            return _UserLibraryReturnModels;
        }
    }
}
