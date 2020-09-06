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
                Status = MatchStatus.finished,

                HomeTeam = "Arsenal",
                HomeTeamScore = 2,
                AwayTeam = "Liverpool",
                AwayTeamScore = 0,
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 2,
                Date = new DateTime(2019, 5, 15, 11, 0, 0),
                Status = MatchStatus.canceled,

                HomeTeam = "Liverpool",
                HomeTeamScore = 0,
                AwayTeam = "Arsenal",
                AwayTeamScore = 0,
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 3,
                Date = new DateTime(2020, 11, 17, 18, 45, 0),
                Status = MatchStatus.upcoming,

                HomeTeam = "Chelsea",
                HomeTeamScore = 0,
                AwayTeam = "New B team",
                AwayTeamScore = 0,
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
                MatchId = 4,
                Date = new DateTime(2020, 8, 15, 20, 30, 0),
                Status = MatchStatus.finished,

                HomeTeam = "Wolverhampton Wanderers",
                HomeTeamScore = 1,
                AwayTeam = "Manchester City",
                AwayTeamScore = 1,
            });

            modelBuilder.Entity<Match>().HasData(new Match
            {
               MatchId = 5,
               Date = new DateTime(2020, 12, 1, 19, 30, 0),
               Status = MatchStatus.upcoming,

               HomeTeam = "Arsenal",
               HomeTeamScore = 0,
               AwayTeam = "Chelsea",
               AwayTeamScore = 0,
            });
        }
    }
}
