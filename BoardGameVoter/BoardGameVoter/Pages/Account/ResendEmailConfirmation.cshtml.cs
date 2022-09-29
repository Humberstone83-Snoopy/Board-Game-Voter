using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Account
{
    public class ResendEmailConfirmationModel : BoardGameVoterPageBase
    {
        //private MailController __MailController;

        public ResendEmailConfirmationModel(IBGVServiceProvider bGVServiceProvider
            //, IMailService mailService) 
            )
        : base(bGVServiceProvider)
        {
            //__MailController = new MailController(mailService);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = UserManager.FindByEmail(Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
                return Page();
            }

            //EmailConfirmationToken token = UserManager.GenerateEmailConfirmationToken(user);

            //string callbackUrl = "/Account/ConfirmEmail?Token=" + token.UID.ToString();

            //await __MailController.SendMailAsync(new MailData(new List<string>() { Email }, "Confirm your email",
            //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."));


            ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
            return Page();
        }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }
    }
}

