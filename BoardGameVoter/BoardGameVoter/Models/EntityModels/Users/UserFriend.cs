using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.Users
{
    [Table("UserFriends")]
    public class UserFriend : EntityBase
    {
        public User Friend { get; set; }

        [ForeignKey("Friend")]
        public int FriendUserID { get; set; }

        public bool IsAccepted { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
    }
}
