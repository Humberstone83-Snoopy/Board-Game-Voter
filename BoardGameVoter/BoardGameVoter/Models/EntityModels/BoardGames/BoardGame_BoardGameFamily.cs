using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGame_BoardGameFamilies")]
    public class BoardGame_BoardGameFamily : EntityBase
    {
        public BoardGame BoardGame { get; set; }

        public BoardGameFamily BoardGameFamily { get; set; }

        [ForeignKey("BoardGameFamily")]
        public int BoardGameFamilyID { get; set; }

        [ForeignKey("BoardGame")]
        public int BoardGameID { get; set; }
    }
}
