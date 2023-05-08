using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.BoardGames
{
    [Table("BoardGameImplementations")]
    public class BoardGameImplementation : EntityBase
    {
        public int BoardGameGeekID { get; set; }
        public string Name { get; set; }
    }
}
