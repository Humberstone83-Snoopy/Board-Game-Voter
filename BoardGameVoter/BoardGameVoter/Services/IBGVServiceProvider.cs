using BoardGameVoter.Services.DBContextService;

namespace BoardGameVoter.Services
{
    public interface IBGVServiceProvider
    {
        IDBContextService DBContextService { get; }
        ILogger Logger { get; }
        ISession Session { get; }
    }
}
