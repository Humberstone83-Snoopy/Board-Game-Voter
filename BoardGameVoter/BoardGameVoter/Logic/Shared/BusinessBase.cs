using BoardGameVoter.Services;

namespace BoardGameVoter.Logic.Shared
{
    public class BusinessBase : IBusinessBase
    {
        private readonly IBGVServiceProvider __BGVServiceProvider;

        public BusinessBase(IBGVServiceProvider bGVServiceProvider)
        {
            __BGVServiceProvider = bGVServiceProvider;
        }

        public IBGVServiceProvider BGVServiceProvider { get { return __BGVServiceProvider; } }
    }
}
