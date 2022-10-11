using BoardGameVoter.Logic.SessionManagers;
using BoardGameVoter.Logic.Shared;
using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.EntityModels.Users;
using BoardGameVoter.Repositorys.EmailConfirmationTokens;
using BoardGameVoter.Repositorys.PasswordResetTokens;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.Users
{
    public class UserManager : BusinessBase, IUserManager
    {
        private readonly EmailConfirmationTokenRepository __EmailConfirmationTokenRepository;
        private readonly PasswordResetTokenRepository __PasswordResetTokenRepository;
        private readonly SessionManager __SessionManager;
        private readonly UserPasswordRepository __UserPasswordRepository;
        private readonly UserRepository __UserRepository;
        private User __User;

        public UserManager(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __UserRepository = new UserRepository(bGVServiceProvider);
            __UserPasswordRepository = new UserPasswordRepository(bGVServiceProvider);
            __PasswordResetTokenRepository = new PasswordResetTokenRepository(bGVServiceProvider);
            __EmailConfirmationTokenRepository = new EmailConfirmationTokenRepository(bGVServiceProvider);
            __SessionManager = new SessionManager(bGVServiceProvider);
        }

        public Task AddToRoleAsync(User user, object p)
        {
            throw new NotImplementedException("Logic/Login/UserManager - AddToRoleAsync");
        }

        public Task<UserUpdateResult> ChangeEmailAsync(User user, string email, string code)
        {
            throw new NotImplementedException("Logic/UserManager - ChangeEmailAsync");
        }

        public User ConfirmEmail(User user, EmailConfirmationToken token)
        {
            if (token != null && token.UserID == user.ID)
            {
                __EmailConfirmationTokenRepository.Delete(token);
                user.IsEmailConfirmed = true;
                __UserRepository.Update(user);
            }
            return user;
        }

        public bool CreateNewUser(User newUser, string password)
        {

            bool _Success = false;
            if (__UserRepository.GetAll().Any(user => user.EmailAddress.Equals(newUser.EmailAddress)))
            {
                return false;
            }

            User = __UserRepository.Add(newUser);
            if (User != null)
            {
                UserPassword _UserPassword = new()
                {
                    UserID = User?.ID ?? 0,
                    PasswordHash = password
                };
                if (__UserPasswordRepository.Add(_UserPassword) != null)
                {
                    _Success = true;
                }
            }

            return _Success;
        }

        public User FindByEmail(string email)
        {
            return __UserRepository.GetByEmail(email);
        }

        public User FindById(int userID)
        {
            return __UserRepository.GetByID(userID);
        }

        public EmailConfirmationToken GenerateEmailConfirmationToken(User user)
        {
            return __EmailConfirmationTokenRepository.GenerateEmailConfirmationToken(user.ID);
        }

        public PasswordResetToken GeneratePasswordResetToken(User user)
        {
            return __PasswordResetTokenRepository.GeneratePasswordResetToken(user.ID);
        }

        public Task<int> GetUserIdAsync(User user)
        {
            throw new NotImplementedException("Logic/Login/UserManager - GetUserIDAsync()");
        }

        public bool IsEmailConfirmed(User user)
        {
            return user.IsEmailConfirmed;
        }

        public UserUpdateResult ResetPassword(User user, PasswordResetToken token, string password)
        {
            UserUpdateResult _UserUpdateResult = new UserUpdateResult();
            if (token != null && token.UserID == user.ID)
            {
                __PasswordResetTokenRepository.Delete(token);
                user.Password.PasswordHash = password;
                __UserPasswordRepository.Update(user.Password);
                _UserUpdateResult.Succeeded = true;
            }
            else
            {
                _UserUpdateResult.Succeeded = false;
            }
            return _UserUpdateResult;
        }

        public Task<UserUpdateResult> SetUserNameAsync(User user, string username)
        {
            throw new NotImplementedException("Logic/UserManager - SetUserNameAsync");
        }

        public User User
        {
            get
            {
                if (__User == null)
                {
                    __User = __SessionManager.User;
                }
                return __User;
            }
            set
            {
                __User = value;
                __SessionManager.AddUser(value);
            }
        }
    }
}
