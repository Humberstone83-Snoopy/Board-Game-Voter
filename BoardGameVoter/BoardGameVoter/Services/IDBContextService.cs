using BoardGameVoter.Data.Shared;

namespace BoardGameVoter.Services
{
    public interface IDBContextService
    {
        IDBContext GetDBContext(Type type);
    }
}
