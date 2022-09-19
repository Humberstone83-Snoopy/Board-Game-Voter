﻿using BoardGameVoter.Data;
using BoardGameVoter.Models.EntityModels;
using BoardGameVoter.Repositorys;

namespace BoardGameVoter.Logic.VoteSessions
{
    public class VoteSessionManager : IVoteSessionManager
    {
        private const int STARTING_VOTE_AMOUNT = 5; // Each user gets 5 votes

        private readonly BoardGameRepository __BoardGameRepository;
        private readonly VoteManager __VoteManager;
        private readonly VoteSessionAttendeeRepository __VoteSessionAttendeeRepository;
        private readonly VoteSessionRepository __VoteSessionRepository;

        public VoteSessionManager(VoteSessionDBContext voteSessionDBContext, VoteSessionAttendeeDBContext voteSessionAttendeeDBContext, VoteDBContext voteDBContext,
            VoteSessionResultDBContext voteSessionResultDBContext, UserDBContext userDBContext, LibraryGameDBContext libraryGameDbContext, BoardGameDBContext boardGameDBContext)
        {
            __VoteSessionRepository = new VoteSessionRepository(voteSessionDBContext);
            __VoteSessionAttendeeRepository = new VoteSessionAttendeeRepository(voteSessionAttendeeDBContext);
            __VoteManager = new VoteManager(voteSessionDBContext, voteSessionAttendeeDBContext, voteDBContext, voteSessionResultDBContext, userDBContext, libraryGameDbContext, boardGameDBContext);
            __BoardGameRepository = new BoardGameRepository(boardGameDBContext);
        }

        public VoteSessionAttendee AddNewAttendee(int userID, int voteSessionID)
        {
            if (!__VoteSessionAttendeeRepository.IsExistingAttendee(voteSessionID, userID))
            {
                __VoteSessionAttendeeRepository.Add(new VoteSessionAttendee()
                {
                    VoteSessionID = voteSessionID,
                    UserID = userID,
                    VotesRemaining = STARTING_VOTE_AMOUNT
                });
            }
            return __VoteSessionAttendeeRepository.GetByVoteSessionID(voteSessionID)
                .FirstOrDefault(attendee => attendee.UserID == userID);
        }

        private void CalculateResults(VoteSession voteSession)
        {
            List<VoteSessionAttendee> _FinalAttendees = __VoteSessionAttendeeRepository.GetByVoteSessionID(voteSession.ID)
                                                            .Where(attendee => attendee.VotesRemaining < STARTING_VOTE_AMOUNT).ToList();
            if (_FinalAttendees.Count != 0)
            {
                for (int MaxPlayers = 0; MaxPlayers <= _FinalAttendees.Count;)
                {
                    int _WinningGameID = __VoteManager.CalculateLeadingGame(voteSession);
                    LibraryGame _ChosenGame = __VoteManager.CreateResult(voteSession.ID, _WinningGameID);
                    BoardGame _GameDetails = __BoardGameRepository.GetByID(_ChosenGame.BoardGameID);
                    MaxPlayers += _GameDetails.MaximumPlayers;
                }
                __VoteManager.ArchiveRemainingVotes(voteSession);
            }
        }

        public void CloseVote(VoteSession voteSession)
        {
            voteSession.IsVotingOpen = false;
            __VoteSessionRepository.Update(voteSession);
            CalculateResults(voteSession);
        }

        public void DeleteSession(VoteSession voteSession)
        {
            __VoteSessionRepository.Delete(voteSession);
        }

        public void RemoveAttendee(int userID, VoteSession voteSession)
        {
            VoteSessionAttendee? _AttendeeToRemove = __VoteSessionAttendeeRepository.GetByUserID(userID).FirstOrDefault(attendee => attendee.VoteSessionID == voteSession.ID);
            if (_AttendeeToRemove != null)
            {
                __VoteSessionAttendeeRepository.Delete(_AttendeeToRemove);

                List<VoteSessionAttendee> _RemainingSessionAttendees = __VoteSessionAttendeeRepository.GetByVoteSessionID(voteSession.ID);

                __VoteManager.RefundVotes(userID, _RemainingSessionAttendees, voteSession);


                if (_RemainingSessionAttendees.Count == 0)
                {
                    DeleteSession(voteSession);
                }
                else if (voteSession.HostUserID == userID)
                {
                    voteSession.HostUserID = _RemainingSessionAttendees.First().UserID;
                    __VoteSessionRepository.Update(voteSession);
                }
            }
        }
    }
}
