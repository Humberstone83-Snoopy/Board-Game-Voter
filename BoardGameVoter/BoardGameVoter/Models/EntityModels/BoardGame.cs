using BoardGameVoter.Models.Enums;
using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("BoardGames")]
    public class BoardGame : EntityBase
    {
        public string Description { get; set; }
        public Difficulty LearningDifficulty { get; set; }
        public int MaximumPlayers { get; set; }
        public int MaxPlayTime { get; set; }
        public int MinimumPlayers { get; set; }
        public int MinimumPlayTime { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
    }
}
