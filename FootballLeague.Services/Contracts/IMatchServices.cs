using FootballLeague.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Services.Contracts
{
    public interface IMatchServices
    {
        Task<Match> GetMatchAsync(int matchId);
        Task<IEnumerable<Match>> GetAllMatchesAsync(int currentPage);

        Task<Match> CreateMatchAsync(Match newMatch);
        Task<Match> EditMatchAsync(Match match);
        Task<Match> DeleteMatchAsync(int matchId);

        Task<IEnumerable<Match>> SearchMatch(string search, int currentPage);
        Task<int> GetPageCount(int matchesPerPage);
    }
}
