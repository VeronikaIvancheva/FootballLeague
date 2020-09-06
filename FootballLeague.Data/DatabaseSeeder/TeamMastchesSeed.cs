using FootballLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Data.DatabaseSeeder
{
    public static class TeamMastchesSeed
    {
        public static void UpdateTeamMatches(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMatches>().HasData(new TeamMatches
            {
               TeamId = 1,
               MatchId = 1,
            });

            modelBuilder.Entity<TeamMatches>().HasData(new TeamMatches
            {
                TeamId = 2,
                MatchId = 1,
            });

            modelBuilder.Entity<TeamMatches>().HasData(new TeamMatches
            {
                TeamId = 3,
                MatchId = 4,
            });

            modelBuilder.Entity<TeamMatches>().HasData(new TeamMatches
            {
                TeamId = 4,
                MatchId = 4,
            });
        }
    }
}
