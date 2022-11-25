using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGameImages")]
    public class BoardGameImage : EntityBase
    {
        public BoardGame BoardGame { get; set; }

        [ForeignKey("BoardGame")]
        public int BoardGameID { get; set; }

        public string FileName { get; set; }
    }
}
