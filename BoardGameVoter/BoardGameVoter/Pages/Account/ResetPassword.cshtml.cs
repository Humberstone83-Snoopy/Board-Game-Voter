using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.PasswordResetTokens;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Account
{
    public class ResetPasswordModel : BoardGameVoterPageBase
    {
        private PasswordResetTokenRepository __PasswordResetTokenRepository;

        public ResetPasswordModel(IBGVServiceProvider bGVServiceProvider)
        : base(bGVServiceProvider)
        {
            __PasswordResetTokenRepository = new PasswordResetTokenRepository(bGVServiceProvider);
        }

        private PasswordResetToken GetToken()
        {
            return __PasswordResetTokenRepository.GetByUID(new Guid(Token));
        }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(Token))
            {
                return BadRequest("A token must be supplied for password reset.");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            PasswordResetToken _ResetToken = GetToken();

            if (_ResetToken == null)
            {
                return BadRequest("A valid token must be supplied for password reset.");
            }

            User user = UserManager.FindByEmail(Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToPage("./ResetPasswordConfirmation");
            }

            UserUpdateResult result = UserManager.ResetPassword(user, _ResetToken, Password);
            if (result.Succeeded)
            {
                return RedirectToPage("./ResetPasswordConfirmation");
            }
            return Page();
        }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [BindProperty]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }
    }
}
