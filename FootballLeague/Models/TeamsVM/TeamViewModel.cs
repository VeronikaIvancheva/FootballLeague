using FootballLeague.Data.Entities;

namespace FootballLeague.Models.TeamsVM
{
    public class TeamViewModel
    {
        public TeamViewModel() { }

        public TeamViewModel(Team team)
        {
            team.TeamId = TeamId;
            team.Name = TeamName;
            team.Scores = TeamScores;
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TeamScores { get; set; }
    }
}
