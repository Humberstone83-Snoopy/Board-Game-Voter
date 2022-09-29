using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.Shared
{
    public interface IBusinessBase
    {
        IBGVServiceProvider BGVServiceProvider { get; }
    }
}
