using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Repositorys;

namespace BoardGameVoter.Logic.VoteSessions
{
    public class VoteManager : IVoteManager
    {
        private readonly LibraryGameRepository __LibraryGameRepository;
        private readonly VoteRepository __VoteRepository;
        private readonly VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private readonly VoteSessionRepository __VoteSessionRepository;
        private readonly VoteSessionResultRepository __VoteSessionResultRepository;

        public VoteManager(VoteSessionDBContext voteSessionDBContext, VoteSessionAttendeeDBContext voteSessionAttendeeDBContext,
            VoteDBContext voteDBContext, VoteSessionResultDBContext voteSessionResultDBContext, UserDBContext userDBContext,
            LibraryGameDBContext libraryGameDbContext, BoardGameDBContext boardGameDBContext)
        {
            __VoteSessionRepository = new VoteSessionRepository(voteSessionDBContext);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(voteSessionAttendeeDBContext, userDBContext, libraryGameDbContext, boardGameDBContext);
            __VoteSessionResultRepository = new VoteSessionResultRepository(voteSessionResultDBContext);
            __VoteRepository = new VoteRepository(voteDBContext);
            __LibraryGameRepository = new LibraryGameRepository(libraryGameDbContext);
        }

        public void ArchiveRemainingVotes(VoteSession voteSession)
        {
            List<LibraryGame> _LibraryGames = __LibraryGameRepository.GetAll();
            List<LibraryGame> _GamesToUpdate = new();
            List<Vote> _Votes = __VoteRepository.GetByVoteSessionID(voteSession.ID);

            foreach (Vote _vote in _Votes)
            {
                LibraryGame? _Game = _LibraryGames.FirstOrDefault(game => game.ID == _vote.LibraryGameID);
                if (_Game != null)
                {
                    _Game.Votes += _vote.NumberOfVotes;
                    _GamesToUpdate.Add(_Game);
                }
            }
            __LibraryGameRepository.Update(_GamesToUpdate);
            __VoteRepository.Delete(_Votes);
        }

        public int CalculateLeadingGame(VoteSession voteSession)
        {
            List<VoteSessionAttendee> _Attendees = __VoteSessionAttendeeRepository.GetByVoteSessionID(voteSession.ID, true, true);
            List<Vote> _Votes = __VoteRepository.GetByVoteSessionID(voteSession.ID);

            LibraryGame? _WinningGame = null;
            int _MostVotes = 0;

            foreach (VoteSessionAttendee _Attendee in _Attendees)
            {
                foreach (LibraryGame _CurrentGame in _Attendee.LibraryGames)
                {
                    int _CurrentGameVotes = CalculateVotes(_CurrentGame, _Votes);
                    if (_CurrentGameVotes > _MostVotes)
                    {
                        _WinningGame = _CurrentGame;
                        _MostVotes = _CurrentGameVotes;
                    }
                    else if (_CurrentGameVotes == _MostVotes)
                    {
                        Random _random = new Random();
                        if (_random.Next(1, 10) > 5)
                        {
                            _WinningGame = _CurrentGame;
                            _MostVotes = _CurrentGameVotes;
                        }
                    }
                }
            }
            return _WinningGame?.ID ?? -1;
        }

        private static int CalculateVotes(LibraryGame libraryGame, List<Vote> sessionVotes)
        {
            return libraryGame.Votes + sessionVotes.Where(vote => vote.LibraryGameID == libraryGame.ID).Select(vote => vote.NumberOfVotes).Sum();
        }

        public LibraryGame CreateResult(int voteSessionID, int libraryGameID)
        {
            LibraryGame _ChosenGame = __LibraryGameRepository.GetByID(libraryGameID);
            __VoteSessionResultRepository.Add(new VoteSessionResult()
            {
                VoteSessionID = voteSessionID,
                LibraryGameID = libraryGameID
            });
            DeleteSpentVotes(voteSessionID, _ChosenGame);
            return _ChosenGame;
        }

        private void DeleteSpentVotes(int voteSessionID, LibraryGame chosenGame)
        {
            chosenGame.Votes = 0;
            __LibraryGameRepository.Update(chosenGame);

            List<Vote> _Votes = __VoteRepository.GetByVoteSessionID(voteSessionID);
            __VoteRepository.Delete(_Votes.Where(vote => vote.LibraryGameID == chosenGame.ID).ToList());
        }

        public int GetUserRemainingVotes(Guid voteSessionUID, int userID)
        {
            VoteSession _CurrentSession = __VoteSessionRepository.GetByUID(voteSessionUID);
            if (_CurrentSession == null)
            {
                throw new ArgumentException("Must pass valid session", nameof(voteSessionUID));
            }
            List<VoteSessionAttendee> _Attendees = __VoteSessionAttendeeRepository.GetByVoteSessionID(_CurrentSession.ID);
            return _Attendees.FirstOrDefault(attendee => attendee.UserID == userID)?.VotesRemaining ?? 0;
        }

        public List<VoteTableModel> GetVoteSessionTable(Guid voteSessionUID)
        {
            List<VoteTableModel> _ReturnModels = new();

            VoteSession _CurrentSession = __VoteSessionRepository.GetByUID(voteSessionUID);
            if (_CurrentSession == null)
            {
                throw new ArgumentException("Must Pass Valid VoteSessionUID", nameof(voteSessionUID));
            }

            List<VoteSessionAttendee> _Attendees = __VoteSessionAttendeeRepository.GetByVoteSessionID(_CurrentSession.ID, true, true);
            List<Vote> _Votes = __VoteRepository.GetByVoteSessionID(_CurrentSession.ID);

            int _RowNumber = 0;

            foreach (VoteSessionAttendee _Attendee in _Attendees)
            {
                foreach (LibraryGame _Game in _Attendee.LibraryGames)
                {
                    if (_Game.BoardGame != null && _Attendee.User != null)
                    {
                        if (_Game.IsAvailable)
                        {
                            _ReturnModels.Add(new VoteTableModel()
                            {
                                LibraryGameID = _Game.ID,
                                LibraryGameUID = _Game.UID,
                                Title = _Game.BoardGame.Title,
                                Description = _Game.BoardGame.Description,
                                Publisher = _Game.BoardGame.Publisher,
                                Players = $"{_Game.BoardGame.MinimumPlayers}-{_Game.BoardGame.MaximumPlayers}",
                                Playtime = $"{_Game.BoardGame.MinimumPlayTime}-{_Game.BoardGame.MaxPlayTime}mins",
                                Owner = $"{_Attendee.User.FirstName} {_Attendee.User.LastName}",
                                Votes = CalculateVotes(_Game, _Votes),
                                RowNumber = _RowNumber
                            });
                            _RowNumber++;
                        }
                    }
                }
            }

            return _ReturnModels;
        }

        public void RefundVotes(int removedUserID, List<VoteSessionAttendee> remainingAttendees, VoteSession voteSession)
        {
            List<LibraryGame> _RemovedUsersLibrary = __LibraryGameRepository.GetByUserID(removedUserID);
            List<Vote> _Votes = __VoteRepository.GetByVoteSessionID(voteSession.ID);

            foreach (Vote vote in _Votes)
            {
                if (_RemovedUsersLibrary.Select(game => game.ID).Contains(vote.LibraryGameID))
                {
                    VoteSessionAttendee? _Attendee = remainingAttendees.FirstOrDefault(attendee => attendee.ID == vote.VoteSessionAttendeeID);
                    if (_Attendee != null)
                    {
                        _Attendee.VotesRemaining += vote.NumberOfVotes;
                        voteSession.VotesCast -= vote.NumberOfVotes;
                        __VoteSessionRepository.Update(voteSession);
                        __VoteSessionAttendeeRepository.Update(_Attendee);
                        __VoteRepository.Delete(vote);
                    }
                }
            }
        }

        public void SaveVotes(Guid voteSessionUID, VoteSessionAttendee attendee, List<Vote> votes)
        {
            VoteSession _CurrentSession = __VoteSessionRepository.GetByUID(voteSessionUID);
            if (_CurrentSession != null && _CurrentSession.IsVotingOpen)
            {
                foreach (Vote _Vote in votes)
                {
                    _CurrentSession.VotesCast += _Vote.NumberOfVotes;
                    attendee.VotesRemaining -= _Vote.NumberOfVotes;

                    __VoteRepository.Add(_Vote);
                    __VoteSessionAttendeeRepository.Update(attendee);
                }
                _CurrentSession.ChosenGameID = CalculateLeadingGame(_CurrentSession);
                __VoteSessionRepository.Update(_CurrentSession);

            }
        }
    }
}
