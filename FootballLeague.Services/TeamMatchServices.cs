using FootballLeague.Data.Context;
using FootballLeague.Data.Entities;
using FootballLeague.Services.Contracts;
using FootballLeague.Services.CustomException;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services
{
    public class TeamMatchServices : ITeamMatchServices
    {
        private readonly FootballLeagueContext _context;
        private readonly ITeamServices _teamServices;

        public TeamMatchServices(FootballLeagueContext context, ITeamServices teamServices)
        {
            this._context = context;
            this._teamServices = teamServices;
        }

        public async void CreateTeamMatch(int teamId, int matchId)
        {
            try
            {
                TeamMatches teamMatch = PassTeamMatchParameters(teamId, matchId);

                await _context.TeamMatches.AddAsync(teamMatch);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public async void HandleNewTeamMatchRequest(Match match)
        {
            try
            {
                Team findHome = await _teamServices.GetTeamByNameAsync(match.HomeTeam);
                Team findAway = await _teamServices.GetTeamByNameAsync(match.AwayTeam);

                CreateTeamMatch(findHome.TeamId, match.MatchId);
                CreateTeamMatch(findAway.TeamId, match.MatchId);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public TeamMatches PassTeamMatchParameters(int teamId, int matchId)
        {
            var newTeamMatches = new TeamMatches
            {
                TeamId = teamId,
                MatchId = matchId,
            };

            return newTeamMatches;
        }
    }
}
