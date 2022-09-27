using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Locations;
using BoardGameVoter.Services;

namespace BoardGameVoter.Pages.Locations
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly LocationRepository __LocationRepository;

        public IndexModel(ISessionManager sessionManager, ILogger<IndexModel> logger, ISignInService service,
            LocationDBContext locationDBContext)
            : base(sessionManager, logger, service)
        {
            __LocationRepository = new LocationRepository(locationDBContext);
        }

        public void OnGet()
        {
            Locations = __LocationRepository.GetAll().ToList();
        }

        public List<Location> Locations { get; set; }
    }
}
