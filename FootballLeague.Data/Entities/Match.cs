using FootballLeague.Data.Enums;
using System;
using System.Collections.Generic;

namespace FootballLeague.Data.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; }

        public byte HomeTeamScore { get; set; }
        public string HomeTeam { get; set; }
        public byte AwayTeamScore { get; set; }
        public string AwayTeam { get; set; }

        public ICollection<TeamMatches> TeamMatches { get; set; }
    }
}
