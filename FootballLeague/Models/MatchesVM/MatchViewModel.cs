using FootballLeague.Data.Entities;
using FootballLeague.Data.Enums;
using System;

namespace FootballLeague.Models.MatchesVM
{
    public class MatchViewModel
    {
        public MatchViewModel() { }

        public MatchViewModel(Match match)
        {
            match.MatchId = MatchId;
            match.Goals = MatchGoals;
            match.Status = MatchStatus;
            match.Date = MatchDate;

            match.HomeTeam = HomeTeam;
            match.AwayTeam = AwayTeam;

            match.MatchResult = MatchResult;
        }

        public int MatchId { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public int MatchGoals { get; set; }
        public DateTime MatchDate { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public string MatchResult { get; set; }
    }
}
