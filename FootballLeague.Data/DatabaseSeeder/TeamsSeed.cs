using FootballLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Data.DatabaseSeeder
{
    public static class TeamsSeed
    {
        public static void UpdateTeams(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 1,
                Name = "Arsenal",
                Scores = 2,
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 2,
                Name = "Liverpool",
                Scores = 0,
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 3,
                Name = "Chelsea",
                Scores = 0,
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 4,
                Name = "Wolverhampton Wanderers",
                Scores = 1,
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 5,
                Name = "Manchester City",
                Scores = 1,
            });
        }
    }
}
