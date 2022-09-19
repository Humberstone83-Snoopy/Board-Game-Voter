using BoardGameVoter.Models.EntityModels;

namespace BoardGameVoter.Models.TableModels
{
    public class LobbyTableModel
    {
        public List<VoteSessionAttendee> Attendees { get; set; }
        public User Host { get; set; }
        public Location Location { get; set; }
        public VoteSession VoteSession { get; set; }
        public LibraryGame WinningGame { get; set; }
    }
}
