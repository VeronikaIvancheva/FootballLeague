using FootballLeague.Data.Entities;

namespace FootballLeague.Services.Contracts
{
    public interface ITeamMatchServices
    {
        void CreateTeamMatch(int teamId, int matchId);

        void HandleNewTeamMatchRequest(Match match);
    }
}
