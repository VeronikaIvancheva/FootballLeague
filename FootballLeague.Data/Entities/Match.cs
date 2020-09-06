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
        public int Goals { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public string MatchResult { get; set; }

        public ICollection<TeamMatches> TeamMatches { get; set; }
    }
}
