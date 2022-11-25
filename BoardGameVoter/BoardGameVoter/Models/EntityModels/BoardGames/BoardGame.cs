using BoardGameVoter.Models.Enums;
using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGames")]
    public class BoardGame : EntityBase
    {
        public string AgeRating { get; set; }
        public virtual BoardGameType? BoardGameType { get; set; }

        [ForeignKey("BoardGameType")]
        public int? BoardGameTypeID { get; set; }

        public List<BoardGame_BoardGameCategory> Categories { get; set; }
        public string Description_Long { get; set; }
        public string Description_Short { get; set; }
        public int? MaximumPlayers { get; set; }

        //Nullable Some games only have a single time provided
        public int? MaximumPlayTime { get; set; }

        public List<BoardGame_BoardGameMechanism> Mechanisms { get; set; }
        public int MinimumPlayers { get; set; }
        public int? MinimumPlayTime { get; set; }
        public string? Publisher { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rating { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Title { get; set; }

        //Nullable some games have no weight
        public Weight? Weight { get; set; }
    }
}
