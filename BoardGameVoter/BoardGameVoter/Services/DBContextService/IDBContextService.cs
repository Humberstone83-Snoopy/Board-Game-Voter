using BoardGameVoter.Data.Shared;

namespace BoardGameVoter.Services.DBContextService
{
    public interface IDBContextService
    {
        IDBContext GetDBContext(Type type);
    }
}
