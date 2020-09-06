using FootballLeague.Data.Context;
using FootballLeague.Data.Entities;
using FootballLeague.Services.Contracts;
using FootballLeague.Services.CustomException;
using System;

namespace FootballLeague.Services
{
    public class TeamMatchServices : ITeamMatchServices
    {
        private readonly FootballLeagueContext _context;

        public TeamMatchServices(FootballLeagueContext context)
        {
            this._context = context;
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
