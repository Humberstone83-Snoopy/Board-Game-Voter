using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Locations;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Locations
{
    public class AddModel : BoardGameVoterPageBase
    {
        private const string REDIRECT_ACTION = "REDIRECT";

        private LocationRepository __LocationRepository;

        public AddModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __LocationRepository = new LocationRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!__LocationRepository.IsPreExisting(Name))
                {
                    __LocationRepository.Add(new Location
                    {
                        Name = Name,
                        Postcode = Postcode,
                        Cost = Cost,
                        Address = Address1 + "\n" + Address2 ?? "" + "\n" + Address3 ?? ""
                    });
                    Action = REDIRECT_ACTION;
                }
                else
                {
                    ErrorMessage = "A location of this name already exists";
                }

            }
        }

        public string Action { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Address1")]
        public string Address1 { get; set; }

        [BindProperty]
        [Display(Name = "Address2")]
        public string? Address2 { get; set; }

        [BindProperty]
        [Display(Name = "Address3")]
        public string? Address3 { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Cost")]
        public decimal Cost { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "PostCode")]
        public string Postcode { get; set; }
    }
}

