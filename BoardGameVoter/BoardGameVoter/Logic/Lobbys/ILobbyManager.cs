using BoardGameVoter.Models.TableModels;

namespace BoardGameVoter.Logic.Lobbys
{
    public interface ILobbyManager
    {
        public List<LobbyTableModel> GetPublicLobby();
    }
}
