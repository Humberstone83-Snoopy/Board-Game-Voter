using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGame_BoardGameArtists")]
    public class BoardGame_BoardGameArtist : EntityBase
    {
        public BoardGame BoardGame { get; set; }

        public BoardGameArtist BoardGameArtist { get; set; }

        [ForeignKey("BoardGameArtist")]
        public int BoardGameArtistID { get; set; }

        [ForeignKey("BoardGame")]
        public int BoardGameID { get; set; }
    }
}
