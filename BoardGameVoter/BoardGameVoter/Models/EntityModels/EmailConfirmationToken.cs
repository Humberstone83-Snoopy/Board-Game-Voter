using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("EmailConfirmationToken")]
    public class EmailConfirmationToken : EntityBase
    {
        public int UserID { get; set; }
    }
}
