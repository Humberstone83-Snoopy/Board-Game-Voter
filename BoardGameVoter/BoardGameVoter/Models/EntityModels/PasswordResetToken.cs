using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("PasswordResetTokens")]
    public class PasswordResetToken : EntityBase
    {
        public int UserID { get; set; }
    }
}
