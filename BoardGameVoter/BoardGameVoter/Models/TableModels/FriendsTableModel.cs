namespace BoardGameVoter.Models.TableModels
{
    public class FriendsTableModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Online { get; set; }
        public int TotalGames { get; set; }
        public Guid UID { get; set; }
        public string Username { get; set; }
    }
}
