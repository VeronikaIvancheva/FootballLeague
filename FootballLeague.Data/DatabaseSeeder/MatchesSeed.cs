using FootballLeague.Data.Entities;
using FootballLeague.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace FootballLeague.Data.DatabaseSeeder
{
    public static class MatchesSeed
    {
        public static void UpdateMatches(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 1,
                Date = new DateTime(2020, 8, 11, 15, 14, 0),
                Goals = 4,
                Status = MatchStatus.finished,

                HomeTeam = "Arsenal",
                AwayTeam = "Liverpool",
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 2,
                Date = new DateTime(2019, 5, 15, 11, 0, 0),
                Goals = 0,
                Status = MatchStatus.canceled,

                HomeTeam = "Liverpool",
                AwayTeam = "Arsenal",
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 3,
                Date = new DateTime(2020, 11, 17, 18, 45, 0),
                Goals = 0,
                Status = MatchStatus.upcoming,

                HomeTeam = "Chelsea",
                AwayTeam = "New B team",
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 4,
                Date = new DateTime(2020, 8, 15, 20, 30, 0),
                Goals = 3,
                Status = MatchStatus.finished,

                HomeTeam = "New A team",
                AwayTeam = "New B team",
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
               MatchId = 5,
               Date = new DateTime(2020, 12, 1, 19, 30, 0),
               Goals = 0,
               Status = MatchStatus.upcoming,

               HomeTeam = "Arsenal",
               AwayTeam = "Chelsea",
            });
        }
    }
}
