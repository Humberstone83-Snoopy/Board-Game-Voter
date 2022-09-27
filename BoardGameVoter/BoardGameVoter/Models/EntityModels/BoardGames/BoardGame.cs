using BoardGameVoter.Models.Enums;
using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGames")]
    public class BoardGame : EntityBase
    {
        public string AgeRating { get; set; }
        public string Description_Long { get; set; }
        public string Description_Short { get; set; }

        public int? MaximumPlayers { get; set; }

        //Nullable Some games only have a single time provided
        public int? MaximumPlayTime { get; set; }

        public int MinimumPlayers { get; set; }
        public int? MinimumPlayTime { get; set; }
        public virtual BoardGameCategory? PrimaryCategory { get; set; }

        [ForeignKey("PrimaryCategory")]
        public int? PrimaryCategoryID { get; set; }

        public virtual BoardGameMechanism? PrimaryMechanism { get; set; }

        [ForeignKey("PrimaryMechanism")]
        public int? PrimaryMechanismID { get; set; }

        public virtual BoardGameType? PrimaryType { get; set; }

        [ForeignKey("PrimaryType")]
        public int? PrimaryTypeID { get; set; }

        public string? Publisher { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public virtual BoardGameCategory? SecondaryCategory { get; set; }

        [ForeignKey("SecondaryCategory")]
        public int? SecondaryCategoryID { get; set; }

        public virtual BoardGameMechanism? SecondaryMechanism { get; set; }

        [ForeignKey("SecondaryMechanism")]
        public int? SecondaryMechanismID { get; set; }

        public virtual BoardGameType? SecondaryType { get; set; }

        [ForeignKey("SecondaryType")]
        public int? SecondaryTypeID { get; set; }

        public virtual BoardGameCategory? TertiaryCategory { get; set; }

        [ForeignKey("TertiaryCategory")]
        public int? TertiaryCategoryID { get; set; }

        public virtual BoardGameMechanism? TertiaryMechanism { get; set; }

        [ForeignKey("TertiaryMechanism")]
        public int? TertiaryMechanismID { get; set; }

        public string Title { get; set; }

        //Nullable some games have no weight
        public Weight? Weight { get; set; }
    }
}
