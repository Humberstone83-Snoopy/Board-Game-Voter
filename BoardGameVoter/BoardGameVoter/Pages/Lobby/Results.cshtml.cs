using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameVoter.Pages.Lobby
{
    public class ResultsModel : BoardGameVoterPageBase
    {
        private readonly LibraryGameRepository __LibraryGameRepository;
        private readonly VoteSessionRepository __VoteSessionRepository;
        private readonly VoteSessionResultRepository __VoteSessionResultRepository;

        public ResultsModel(ISessionManager sessionManager, ILogger<ResultsModel> logger, ISignInService service, VoteSessionResultDBContext voteSessionResultDBContext,
            VoteSessionDBContext voteSessionDBContext, LibraryGameDBContext libraryGameDbContext, BoardGameDBContext boardGameDBContext)
            : base(sessionManager, logger, service)
        {
            __VoteSessionResultRepository = new VoteSessionResultRepository(voteSessionResultDBContext);
            __VoteSessionRepository = new VoteSessionRepository(voteSessionDBContext);
            __LibraryGameRepository = new LibraryGameRepository(libraryGameDbContext, boardGameDBContext);
        }

        public void OnGet()
        {
            VoteSession = __VoteSessionRepository.GetByUID(VoteSessionUID);
            Results = __VoteSessionResultRepository.GetByVoteSessionID(VoteSession.ID);
            LibraryGames = __LibraryGameRepository.GetByID(Results.Select(result => result.LibraryGameID), true);
        }

        public List<LibraryGame> LibraryGames { get; set; }
        public List<VoteSessionResult> Results { get; set; }
        public VoteSession VoteSession { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid VoteSessionUID { get; set; }
    }
}
