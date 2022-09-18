using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels
{
    [Table("UserSessions")]
    public class UserSession : EntityBase
    {
        public DateTime LastInteraction { get; set; }
        public DateTime SessionStartTime { get; set; }
        public int UserID { get; set; }
    }
}
