using BoardGameVoter.Data;
using BoardGameVoter.Data.Shared;

namespace BoardGameVoter.Services
{
    public class DBContextService : IDBContextService
    {
        public DBContextService(
            BoardGameDBContext boardGameDBContext,
            EmailConfirmationTokenDBContext emailConfirmationTokenDBContext,
            LibraryGameDBContext libraryGameDBContext,
            LocationDBContext locationDBContext,
            PasswordResetTokenDBContext passwordResetTokenDBContext,
            UserDBContext userDBContext,
            UserSessionDBContext userSessionDBContext,
            VoteSessionDBContext voteSessionDBContext)
        {
            DBContexts = new()
            {
                boardGameDBContext,
                emailConfirmationTokenDBContext,
                libraryGameDBContext,
                locationDBContext,
                passwordResetTokenDBContext,
                userDBContext,
                userSessionDBContext,
                voteSessionDBContext
            };
        }

        public IDBContext GetDBContext(Type type)
        {
            IDBContext? _Context = null;
            string _SearchString = type.ToString().Split(".")[^1] + "DBContext";
            foreach (IDBContext context in DBContexts)
            {
                string _CurrentContextName = context.GetType().ToString().Split(".")[^1];
                if (_SearchString == _CurrentContextName)
                {
                    _Context = context;
                    break;
                }
            }
            if (_Context == null)
            {
                throw new ArgumentNullException(nameof(IDBContext), "DBContext Not Found");
            }
            return _Context;
        }

        private List<IDBContext> DBContexts { get; set; }
    }
}
