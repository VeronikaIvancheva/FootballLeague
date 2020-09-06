using FootballLeague.Data.Context;
using FootballLeague.Data.Entities;
using FootballLeague.Services.Contracts;
using FootballLeague.Services.CustomException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services
{
    public class MatchServices : IMatchServices
    {
        private readonly FootballLeagueContext _context;
        private readonly ITeamServices _teamServices;
        private readonly ITeamMatchServices _teamMatchServices;

        public MatchServices(FootballLeagueContext context, ITeamServices teamServices,
            ITeamMatchServices teamMatchServices)
        {
            this._context = context;
            this._teamServices = teamServices;
            this._teamMatchServices = teamMatchServices;
        }

        #region =======GET Methods=======
        public async Task<Match> GetMatchAsync(int matchId)
        {
            Match match = await _context.Matches
                .Include(tm => tm.TeamMatches)
                .OrderBy(d => d.Date)
                .ThenBy(s => s.Status)
                .FirstOrDefaultAsync(t => t.MatchId == matchId);

            if (match == null)
            {
                throw new GlobalException(MatchesExceptionMessage.NoMatch);
            }

            return match;
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync(int currentPage)
        {
            IEnumerable<Match> allMatches = _context.Matches;

            if (currentPage == 1)
            {
                allMatches = allMatches
                     .Take(10);
            }
            else
            {
                allMatches = allMatches
                    .Skip((currentPage - 1) * 10)
                    .Take(10);
            }

            allMatches
                .OrderBy(d => d.Date)
                .ThenBy(s => s.Status)
                .ToList();

            return allMatches;
        }
        #endregion

        #region =======Create, Edit, Delete Methods=======
        public async Task<Match> CreateMatchAsync(Match newMatch)
        {
            await _teamServices.CheckIfTeamExcist(newMatch);

            try
            {
                Match match = PassMatchParameters(newMatch);

                await _context.Matches.AddAsync(match);
                await _context.SaveChangesAsync();

                _teamMatchServices.HandleNewTeamMatchRequest(match);

                return match;
            }
            catch (Exception)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public async Task<Match> EditMatchAsync(Match match)
        {
            Match currentMatch = await GetMatchAsync(match.MatchId);

            if (currentMatch == null)
            {
                throw new ArgumentNullException(MatchesExceptionMessage.NoMatch);
            }

            await _teamServices.CheckIfTeamExcist(match);

            try
            {
                _context.Entry(currentMatch).CurrentValues.SetValues(match);
                await _context.SaveChangesAsync();

                return match;
            }
            catch (GlobalException)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public async Task<Match> DeleteMatchAsync(int matchId)
        {
            Match matchForRemove = await GetMatchAsync(matchId);

            if (matchForRemove == null)
            {
                throw new ArgumentNullException(MatchesExceptionMessage.NoMatch);
            }

            try
            {
                _context.Matches.Remove(matchForRemove);
                await _context.SaveChangesAsync();

                return matchForRemove;
            }
            catch (GlobalException)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }
        #endregion

        public async Task<IEnumerable<Match>> SearchMatch(string search, int currentPage)
        {
            try
            {
                IEnumerable<Match> searchResult = _context.Matches
                    .Where(b => b.Status.ToString().Contains(search) ||
                                b.Date.ToString().Contains(search) ||
                                b.AwayTeam.Contains(search) ||
                                b.HomeTeam.Contains(search));

                if (currentPage == 1)
                {
                    searchResult = searchResult
                    .Take(10);
                }
                else
                {
                    searchResult = searchResult
                    .Skip((currentPage - 1) * 10)
                    .Take(10);
                }

                searchResult
                    .OrderBy(b => b.Status)
                    .ThenBy(d => d.Date)
                    .ToList();

                return searchResult;
            }
            catch (GlobalException)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }
        public async Task<int> GetPageCount(int matchesPerPage)
        {
            var allMatches = await _context.Matches
                .CountAsync();

            var totalPages = (allMatches - 1) / matchesPerPage + 1;

            return totalPages;
        }
        public Match PassMatchParameters(Match match)
        {
            var newMatch = new Match
            {
                Status = match.Status,
                Date = match.Date,

                AwayTeam = match.AwayTeam,
                AwayTeamScore = match.AwayTeamScore,
                HomeTeam = match.HomeTeam,
                HomeTeamScore = match.HomeTeamScore,
            };

            return newMatch;
        }
    }
}
