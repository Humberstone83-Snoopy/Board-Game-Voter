using BoardGameVoter.Logic.Lobbys;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;


namespace BoardGameVoter.Pages.Lobby
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly LobbyManager __LobbyManager;
        //private readonly BoardGameRepository __BoardGameRepository;

        public IndexModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __LobbyManager = new LobbyManager(bGVServiceProvider);
            //__BoardGameRepository = new BoardGameRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
            PublicLobby = __LobbyManager.GetPublicLobby();

            //using (var reader = new StreamReader("C:\\Users\\JackHumberstone\\source\\repos\\humberstone83\\board-game-voter\\BoardGameVoter\\BoardGameVoter\\bgg-combined.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    using (var dr = new CsvDataReader(csv))
            //    {
            //        var dt = new DataTable();
            //        dt.Columns.Add("Title", typeof(string));
            //        dt.Columns.Add("Date", typeof(string));
            //        dt.Columns.Add("Rating", typeof(decimal));
            //        dt.Columns.Add("Description_Short", typeof(string));
            //        dt.Columns.Add("Minimum_Players", typeof(int));
            //        dt.Columns.Add("Maximum_Players", typeof(int));
            //        dt.Columns.Add("Minimum_Playtime", typeof(int));
            //        dt.Columns.Add("Maximum_Playtime", typeof(int));
            //        dt.Columns.Add("Age", typeof(string));
            //        dt.Columns.Add("Weight", typeof(decimal));
            //        dt.Columns.Add("Publisher", typeof(string));
            //        dt.Columns.Add("Type_Primary_ID", typeof(int));
            //        dt.Columns.Add("Type_Secondary_ID", typeof(int));
            //        dt.Columns.Add("Category_Primary_ID", typeof(int));
            //        dt.Columns.Add("Category_Secondary_ID", typeof(int));
            //        dt.Columns.Add("Category_Tertiary_ID", typeof(int));
            //        dt.Columns.Add("Mechanic_Primary_ID", typeof(int));
            //        dt.Columns.Add("Mechanic_Secondary_ID", typeof(int));
            //        dt.Columns.Add("Mechanic_Tertiary_ID", typeof(int));
            //        dt.Columns.Add("Description_Long", typeof(string));
            //        dt.Load(dr);

            //        List<BoardGame> _Games = new();
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            _Games.Add(new()
            //            {
            //                Title = row["Title"] as string,
            //                ReleaseDate = DateTime.Parse("01/01/" + row["Date"] as string),
            //                Rating = row["Rating"] as decimal? ?? 0,
            //                Description_Short = row["Description_Short"] as string,
            //                MinimumPlayers = row["Minimum_Players"] as int? ?? 0,
            //                MaximumPlayers = row["Maximum_Players"] as int? ?? 0,
            //                MinimumPlayTime = row["Minimum_Playtime"] as int? ?? 0,
            //                MaximumPlayTime = row["Maximum_Playtime"] as int? ?? 0,
            //                AgeRating = row["Age"] as string,
            //                Weight = (Weight)(int)Math.Round(row["Weight"] as decimal? ?? 0),
            //                Publisher = row["Publisher"] as string,
            //                PrimaryTypeID = ((row["Type_Primary_ID"] as int? ?? 0) > 0) ? (row["Type_Primary_ID"] as int? ?? 0) : null,
            //                SecondaryTypeID = ((row["Type_Secondary_ID"] as int? ?? 0) > 0) ? (row["Type_Secondary_ID"] as int? ?? 0) : null,
            //                PrimaryCategoryID = ((row["Category_Primary_ID"] as int? ?? 0) > 0) ? (row["Category_Primary_ID"] as int? ?? 0) : null,
            //                SecondaryCategoryID = ((row["Category_Secondary_ID"] as int? ?? 0) > 0) ? (row["Category_Secondary_ID"] as int? ?? 0) : null,
            //                TertiaryCategoryID = ((row["Category_Tertiary_ID"] as int? ?? 0) > 0) ? (row["Category_Tertiary_ID"] as int? ?? 0) : null,
            //                PrimaryMechanismID = ((row["Mechanic_Primary_ID"] as int? ?? 0) > 0) ? (row["Mechanic_Primary_ID"] as int? ?? 0) : null,
            //                SecondaryMechanismID = ((row["Mechanic_Secondary_ID"] as int? ?? 0) > 0) ? (row["Mechanic_Secondary_ID"] as int? ?? 0) : null,
            //                TertiaryMechanismID = ((row["Mechanic_Tertiary_ID"] as int? ?? 0) > 0) ? (row["Mechanic_Tertiary_ID"] as int? ?? 0) : null,
            //                Description_Long = row["Description_Long"] as string
            //            });
            //        }
            //            __BoardGameRepository.Add(_Games);
            //    }
            //}
        }

        public List<LobbyTableModel> PublicLobby { get; set; }
    }
}

