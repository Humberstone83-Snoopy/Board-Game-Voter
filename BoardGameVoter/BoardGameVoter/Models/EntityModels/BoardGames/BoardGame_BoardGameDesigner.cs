using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGame_BoardGameDesigners")]
    public class BoardGame_BoardGameDesigner : EntityBase
    {
        public BoardGame BoardGame { get; set; }

        public BoardGameDesigner BoardGameDesigner { get; set; }

        [ForeignKey("BoardGameDesigner")]
        public int BoardGameDesignerID { get; set; }

        [ForeignKey("BoardGame")]
        public int BoardGameID { get; set; }
    }
}
