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
            match.Status = MatchStatus;
            match.Date = MatchDate;

            match.HomeTeam = HomeTeam;
            match.HomeTeamScore = HomeTeamScore;
            match.AwayTeam = AwayTeam;
            match.AwayTeamScore = AwayTeamScore;
        }

        public int MatchId { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public DateTime MatchDate { get; set; }

        public string HomeTeam { get; set; }
        public byte HomeTeamScore { get; set; }
        public string AwayTeam { get; set; }
        public byte AwayTeamScore { get; set; }
    }
}
