using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGameArtists")]
    public class BoardGameArtist : EntityBase
    {
        public int BoardGameGeekID { get; set; }
        public string Name { get; set; }
    }
}
