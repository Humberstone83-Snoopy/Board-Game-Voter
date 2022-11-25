using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGame_BoardGameMechanisms")]
    public class BoardGame_BoardGameMechanism : EntityBase
    {
        public BoardGame BoardGame { get; set; }

        [ForeignKey("BoardGame")]
        public int BoardGameID { get; set; }

        public BoardGameMechanism BoardGameMechanism { get; set; }

        [ForeignKey("BoardGameMechanism")]
        public int BoardGameMechanismID { get; set; }
    }
}
