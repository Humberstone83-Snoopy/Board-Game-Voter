namespace BoardGameVoter.Models.TableModels
{
    public class VoteTableModel
    {
        public string Description { get; set; }
        public int LibraryGameID { get; set; }
        public Guid LibraryGameUID { get; set; }
        public string Owner { get; set; }
        public string Players { get; set; }
        public string Playtime { get; set; }
        public string Publisher { get; set; }
        public int RowNumber { get; set; }
        public string Title { get; set; }
        public int Votes { get; set; }
    }
}
