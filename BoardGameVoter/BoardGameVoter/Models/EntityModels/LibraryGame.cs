using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("LibraryGames")]
    public class LibraryGame : EntityBase
    {
        [NotMapped]
        public BoardGame BoardGame { get; set; }

        public int BoardGameID { get; set; }
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public int Votes { get; set; }
    }
}
