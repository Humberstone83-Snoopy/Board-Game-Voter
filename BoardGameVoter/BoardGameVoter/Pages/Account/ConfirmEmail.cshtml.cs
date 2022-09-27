using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.EmailConfirmationTokens;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Account
{
    public class ConfirmEmailModel : BoardGameVoterPageBase
    {
        private EmailConfirmationTokenRepository __EmailConfirmationTokenRepository;

        public ConfirmEmailModel(ISessionManager sessionManager, ILogger<ConfirmEmailModel> logger, ISignInService signInService, 
            EmailConfirmationTokenDBContext emailConfirmationTokenDBContext)
            
            : base(sessionManager, logger, signInService)
        {
            __EmailConfirmationTokenRepository = new EmailConfirmationTokenRepository(emailConfirmationTokenDBContext);
        }

        private EmailConfirmationToken GetToken()
        {
            return __EmailConfirmationTokenRepository.GetByUID(new Guid(Token));
        }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(Token))
            {
                return RedirectToPage("/Index");
            }

            EmailConfirmationToken _Token = GetToken();

            if (_Token == null)
            {

                return RedirectToPage("/Index");

            }

            User user = UserManager.FindById(_Token.UserID);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_Token.UserID}'.");
            }

            user = UserManager.ConfirmEmail(user, _Token);
            StatusMessage = user.IsEmailConfirmed ? "Thank you for confirming your email." : "Error confirming your email.";

            if (user.IsEmailConfirmed)
            {
                SignInManager.SignIn(user);
            }

            return Page();
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

    }
}