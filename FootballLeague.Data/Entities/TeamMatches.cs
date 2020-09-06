
namespace FootballLeague.Data.Entities
{
    public class TeamMatches
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }


        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
