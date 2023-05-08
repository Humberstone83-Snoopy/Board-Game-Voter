using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGame_BoardGamePublishers")]
    public class BoardGame_BoardGamePublisher : EntityBase
    {
        public BoardGame BoardGame { get; set; }

        public BoardGamePublisher BoardGamePublisher { get; set; }

        [ForeignKey("BoardGamePublisher")]
        public int BoardGamePublisherID { get; set; }

        [ForeignKey("BoardGame")]
        public int BoardGameID { get; set; }
    }
}
