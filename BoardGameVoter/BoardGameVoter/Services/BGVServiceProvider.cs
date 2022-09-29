using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.Users;
using BoardGameVoter.Services.DBContextService;

namespace BoardGameVoter.Services
{
    public class BGVServiceProvider : IBGVServiceProvider
    {
        private readonly ILogger<BoardGameVoterPageBase> __Logger;
        private readonly IHttpContextAccessor __ContextAccessor;
        private readonly IDBContextService __DBContextService;

        public BGVServiceProvider(IDBContextService dbContextService, ILogger<BoardGameVoterPageBase> logger, IHttpContextAccessor accessor)
        {
            __Logger = logger;
            __ContextAccessor = accessor;
            __DBContextService = dbContextService;
        }

        public IDBContextService DBContextService { get => __DBContextService; }
        public ILogger Logger { get => __Logger; }
        public ISession Session { get => __ContextAccessor.HttpContext?.Session ?? null; }

    }
}
