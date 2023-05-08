using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGameMechanisms")]
    public class BoardGameMechanism : EntityBase
    {
        public int BoardGameGeekID { get; set; }
        public string Name { get; set; }
    }
}
