
using System.Collections.Generic;

namespace FootballLeague.Data.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Scores { get; set; }

        public ICollection<TeamMatches> TeamMatches { get; set; }
    }
}
