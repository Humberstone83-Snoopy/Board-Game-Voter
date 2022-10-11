using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.Users
{
    [Table("UserNotifications")]
    public class UserNotification : EntityBase
    {
        public string Header { get; set; }
        public bool IsOpened { get; set; }
        public string Message { get; set; }

        [ForeignKey("User")]
        public int RecipientUserID { get; set; }

        public int? SendeeUserID { get; set; }
        public DateTime SentDate { get; set; }
        public User User { get; set; }
    }
}
