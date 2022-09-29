using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Locations;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Locations
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly LocationRepository __LocationRepository;

        public IndexModel(IBGVServiceProvider bGVServiceProvider)
            : base(bGVServiceProvider)
        {
            __LocationRepository = new LocationRepository(bGVServiceProvider);
        }

        public void OnGet()
        {
            Locations = __LocationRepository.GetAll().ToList();
        }

        public List<Location> Locations { get; set; }
    }
}
