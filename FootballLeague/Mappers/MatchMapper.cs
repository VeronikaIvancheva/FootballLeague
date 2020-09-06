using FootballLeague.Data.Entities;
using FootballLeague.Models.MatchesVM;
using System.Collections.Generic;

namespace FootballLeague.Mappers
{
    public static class MatchMapper
    {
        #region Map from Data
        public static MatchViewModel MapMatch(this Match match)
        {
            MatchViewModel matchModel = new MatchViewModel
            {
                MatchId = match.MatchId,
                MatchStatus = match.Status,
                MatchDate = match.Date,

                AwayTeam = match.AwayTeam,
                AwayTeamScore = match.AwayTeamScore,
                HomeTeam = match.HomeTeam,
                HomeTeamScore = match.HomeTeamScore,
            };

            return matchModel;
        }
        #endregion

        #region Map from view model
        public static Match MapMatch(this MatchViewModel matchVM)
        {
            Match matchModel = new Match
            {
                MatchId = matchVM.MatchId,
                Date = matchVM.MatchDate,
                Status = matchVM.MatchStatus,

                HomeTeam = matchVM.HomeTeam,
                HomeTeamScore = matchVM.HomeTeamScore,
                AwayTeam = matchVM.AwayTeam,
                AwayTeamScore = matchVM.AwayTeamScore,
            };

            return matchModel;
        }
        #endregion

        public static MatchIndexViewMode MapFromMatchIndex(this IEnumerable<MatchViewModel> matches,
            int currentPage, int totalPages)
        {
            var model = new MatchIndexViewMode
            {
                Matches = matches,
                CurrentPage = currentPage,
                TotalPages = totalPages,
            };

            return model;
        }
    }
}
