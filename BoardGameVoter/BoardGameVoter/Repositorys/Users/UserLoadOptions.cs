using BoardGameVoter.Repositorys.Shared;

namespace BoardGameVoter.Repositorys.Users
{
    public class UserLoadOptions : RepositoryLoadOptions
    {
        public bool LoadWithFriends { get; set; } = false;
        public bool LoadWithNotifications { get; set; } = false;
    }
}
