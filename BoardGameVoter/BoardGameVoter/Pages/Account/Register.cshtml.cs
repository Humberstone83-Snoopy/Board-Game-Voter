using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace BoardGameVoter.Pages.Account
{
    public class RegisterModel : BoardGameVoterPageBase
    {
        private const bool REQUIRECONFIRMEDACCOUNT = false;

        //private MailController _mailController;

        public RegisterModel(IBGVServiceProvider bGVServiceProvider
            //, IMailService mailService) 
            )
            : base(bGVServiceProvider)
        {
            //_mailController = new MailController(mailService);
        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                MailAddress address = new(Email);
                string userName = address.User;
                var user = new User
                {
                    Age = Age,
                    CreatedDate = DateTime.Now,
                    EmailAddress = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = userName,
                    UID = Guid.NewGuid()

                };
                var result = UserManager.CreateNewUser(user, Password);
                if (result)
                {
                    Logger.LogInformation("User created a new account with password.");

                    //EmailConfirmationToken token = UserManager.GenerateEmailConfirmationToken(user);

                    //string callbackUrl = "/Account/ConfirmEmail?Token=" + token.UID.ToString();

                    //await _mailController.SendMailAsync(new MailData(new List<string>() { Email }, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."));

                    if (REQUIRECONFIRMEDACCOUNT)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        SignInManager.SignIn(user);
                        return LocalRedirect(returnUrl);
                    }
                }
                //TODO: Add Error feedback
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        [Display(Name = "Age")]
        [BindProperty]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "First Name")]
        [BindProperty]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [BindProperty]
        public string LastName { get; set; } = string.Empty;

        //has to sit in front of Confirm in order for compare to work 
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [BindProperty]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(otherProperty: "Password", ErrorMessage = "The password and confirmation password do not match.")]
        [BindProperty]
        public string PasswordConfirm { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
