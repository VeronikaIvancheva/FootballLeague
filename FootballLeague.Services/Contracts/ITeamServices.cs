using FootballLeague.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Services.Contracts
{
    public interface ITeamServices
    {
        Task<Team> GetTeamAsync(int id);
        Task<Team> GetTeamByNameAsync(string teamName);
        Task<IEnumerable<Team>> GetAllTeamsAsync(int currentPage);

        Task<Team> CreateTeamAsync(Team newTeam);
        Task<Team> CreateTeamAsync(string newTeam);
        Task<Team> EditTeamAsync(Team team);
        Task<Team> DeleteTeamAsync(int teamId);

        Task<IEnumerable<Team>> SearchTeam(string search, int currentPage);
        Task<int> GetPageCount(int teamsPerPage);
    }
}
