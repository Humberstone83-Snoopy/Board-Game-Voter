using BoardGameVoter.Models.Enums;
using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGames")]
    public class BoardGame : EntityBase
    {
        public string AgeRating { get; set; }
        public List<BoardGame_BoardGameArtist> Artists { get; set; }
        public int BoardGameGeekID { get; set; }
        public List<BoardGame_BoardGameCategory> Categories { get; set; }
        public string Description { get; set; }
        public List<BoardGame_BoardGameDesigner> Designers { get; set; }
        public List<BoardGame_BoardGameFamily> Families { get; set; }
        public List<BoardGameImplementation> Implementations { get; set; }
        public int? MaximumPlayers { get; set; }
        public int? MaximumPlayTime { get; set; }
        public List<BoardGame_BoardGameMechanism> Mechanisms { get; set; }
        public int MinimumPlayers { get; set; }
        public int? MinimumPlayTime { get; set; }
        public List<BoardGame_BoardGamePublisher> Publishers { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rating { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }
        public Weight? Weight { get; set; }
    }
}
