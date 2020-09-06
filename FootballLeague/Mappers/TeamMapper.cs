using FootballLeague.Data.Entities;
using FootballLeague.Models.TeamsVM;
using System.Collections.Generic;

namespace FootballLeague.Mappers
{
    public static class TeamMapper
    {
        #region Map from Data
        public static TeamViewModel MapTeam(this Team team)
        {
            TeamViewModel teamVM = new TeamViewModel
            {
                TeamId = team.TeamId,
                TeamName = team.Name,
                TeamScores = team.Scores,
            };

            return teamVM;
        }
        #endregion

        #region Map from view model
        public static Team MapTeam(this TeamViewModel teamVM)
        {
            Team teamModel = new Team
            {
                TeamId = teamVM.TeamId,
                Name = teamVM.TeamName,
                Scores = teamVM.TeamScores,

            };

            return teamModel;
        }
        #endregion

        public static TeamIndexViewMode MapFromTeamIndex(this IEnumerable<TeamViewModel> team,
            int currentPage, int totalPages)
        {
            var teamModel = new TeamIndexViewMode
            {
                Teams = team,
                CurrentPage = currentPage,
                TotalPages = totalPages,
            };

            return teamModel;
        }
    }
}
