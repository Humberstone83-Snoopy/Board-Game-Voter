using BoardGameVoter.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameVoter.Models.EntityModels.Users
{
    [Table("UserPasswords")]
    public class UserPassword : EntityBase
    {
        public string PasswordHash { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
    }
}
