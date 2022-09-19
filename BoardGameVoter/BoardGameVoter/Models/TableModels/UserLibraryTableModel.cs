namespace BoardGameVoter.Models.TableModels
{
    public class UserLibraryTableModel
    {
        public string Description { get; set; }
        public int ID { get; set; }
        public bool IsAvailable { get; set; }
        public string Players { get; set; }
        public string Playtime { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public Guid UID { get; set; }
    }
}
