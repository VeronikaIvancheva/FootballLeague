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
    public class TeamServices : ITeamServices
    {
        private readonly FootballLeagueContext _context;

        public TeamServices(FootballLeagueContext context)
        {
            this._context = context;
        }

        #region =======GET Methods=======
        public async Task<Team> GetTeamAsync(int id)
        {
            Team team = await _context.Teams
                .Include(tm => tm.TeamMatches)
                .OrderBy(s => s.Scores)
                .ThenBy(n => n.Name)
                .FirstOrDefaultAsync(t => t.TeamId == id);

            if (team == null)
            {
                throw new GlobalException(TeamsExceptionMessage.NoTeam);
            }

            return team;
        }

        public async Task<Team> GetTeamByNameAsync(string teamName)
        {
            Team team = await _context.Teams
                .FirstOrDefaultAsync(n => n.Name == teamName);

            return team;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync(int currentPage)
        {
            IEnumerable<Team> allTeams = _context.Teams;

            if (currentPage == 1)
            {
                allTeams = allTeams
                     .Take(10);
            }
            else
            {
                allTeams = allTeams
                    .Skip((currentPage - 1) * 10)
                    .Take(10);
            }

            allTeams
                .OrderBy(s => s.Scores)
                .ThenBy(n => n.Name)
                .ToList();

            return allTeams;
        }
        #endregion

        #region =======Create, Edit, Delete Methods=======
        public async Task<Team> CreateTeamAsync(Team newTeam)
        {
            try
            {
                Team team = PassTeamParameters(newTeam);

                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();

                return team;
            }
            catch (Exception)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public async Task<Team> CreateTeamAsync(string newTeam)
        {
            try
            {
                Team team = PassTeamParameters(newTeam);

                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();

                return team;
            }
            catch (Exception)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public async Task<Team> EditTeamAsync(Team team)
        {
            Team currentTeam = await GetTeamAsync(team.TeamId);

            if (currentTeam == null)
            {
                throw new ArgumentNullException(TeamsExceptionMessage.NoTeam);
            }

            try
            {
                _context.Entry(currentTeam).CurrentValues.SetValues(team);
                await _context.SaveChangesAsync();

                return team;
            }
            catch (GlobalException)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public async Task<Team> DeleteTeamAsync(int teamId)
        {
            Team teamForRemove = await GetTeamAsync(teamId);

            if (teamForRemove == null)
            {
                throw new ArgumentNullException(TeamsExceptionMessage.NoTeam);
            }

            try
            {
                _context.Teams.Remove(teamForRemove);
                await _context.SaveChangesAsync();

                return teamForRemove;
            }
            catch (GlobalException)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }
        #endregion

        public async Task<IEnumerable<Team>> SearchTeam(string search, int currentPage)
        {
            try
            {
                IEnumerable<Team> searchResult = _context.Teams
                    .Where(b => b.Name.Contains(search) ||
                                b.Scores.ToString().Contains(search));

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
                    .OrderBy(b => b.Name)
                    .ToList();

                return searchResult;
            }
            catch (GlobalException)
            {
                throw new GlobalException(GlobalExceptionMessage.GlobalErrorMessage);
            }
        }

        public async Task<int> GetPageCount(int teamsPerPage)
        {
            var allTeams = await _context.Teams
                .CountAsync();

            var totalPages = (allTeams - 1) / teamsPerPage + 1;

            return totalPages;
        }
        public Team PassTeamParameters(Team team)
        {
            var newTeam = new Team
            {
                Name = team.Name,
                Scores = team.Scores,
            };

            return newTeam;
        }

        public Team PassTeamParameters(string team)
        {
            var newTeam = new Team
            {
                Name = team,
                Scores = 0,
            };

            return newTeam;
        }
    }
}
