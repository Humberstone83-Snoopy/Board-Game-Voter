using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGame_BoardGameCategories")]
    public class BoardGame_BoardGameCategory : EntityBase
    {
        public BoardGame BoardGame { get; set; }

        public BoardGameCategory BoardGameCategory { get; set; }

        [ForeignKey("BoardGameCategory")]
        public int BoardGameCategoryID { get; set; }

        [ForeignKey("BoardGame")]
        public int BoardGameID { get; set; }
    }
}
