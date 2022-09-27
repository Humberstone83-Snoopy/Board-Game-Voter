using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGameTypes")]
    public class BoardGameType : EntityBase
    {
        public string Name { get; set; }
    }
}
