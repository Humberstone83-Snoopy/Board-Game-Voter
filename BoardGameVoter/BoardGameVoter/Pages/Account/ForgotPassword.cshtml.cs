using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Account
{
    public class ForgotPasswordModel : BoardGameVoterPageBase
    {
        //private MailController _mailController;

        public ForgotPasswordModel(ISessionManager sessionManager, ILogger<ForgotPasswordModel> logger, ISignInService signInService
            //, IMailService mailService) 
            )
            : base(sessionManager, logger, signInService)
        {
            //_mailController = new MailController(mailService);
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByEmail(Email);
                if (user == null || !user.IsEmailConfirmed)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }


                //Jack IDEA
                //DBTable PasswordresetTokens (id,uid,userid)
                //use this uid as token to add to querystring of request
                //on ResetPassword take that uid and use it to validate sesion

                //PasswordResetToken resetToken = UserManager.GeneratePasswordResetToken(user);
                //string callbackUrl = "/Account/ResetPassword?ResetToken=" + resetToken.UID.ToString();

                //await _mailController.SendMailAsync(new MailData(new List<string>() { Email }, "Reset Password",
                //    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."));

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }

        [Required]
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
    }
}
