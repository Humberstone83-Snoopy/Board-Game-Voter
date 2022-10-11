using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.Users;

namespace BoardGameVoter.Logic.Users
{
    public interface IUserManager
    {
        Task AddToRoleAsync(User user, object p);
        Task<UserUpdateResult> ChangeEmailAsync(User user, string email, string code);
        User ConfirmEmail(User user, EmailConfirmationToken token);
        bool CreateNewUser(User user, string password);
        User FindByEmail(string email);
        User FindById(int id);
        EmailConfirmationToken GenerateEmailConfirmationToken(User user);
        PasswordResetToken GeneratePasswordResetToken(User user);
        Task<int> GetUserIdAsync(User user);
        bool IsEmailConfirmed(User user);
        UserUpdateResult ResetPassword(User user, PasswordResetToken token, string password);
        Task<UserUpdateResult> SetUserNameAsync(User user, string username);

        User User { get; set; }
    }
}