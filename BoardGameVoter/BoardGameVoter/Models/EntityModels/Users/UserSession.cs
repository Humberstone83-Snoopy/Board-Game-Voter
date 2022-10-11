using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.Users
{
    [Table("UserSessions")]
    public class UserSession : EntityBase
    {
        public DateTime LastInteraction { get; set; }
        public DateTime SessionStartTime { get; set; }

        public virtual User? User { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }
    }
}
