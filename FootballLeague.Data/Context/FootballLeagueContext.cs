using FootballLeague.Data.Context.Configurations;
using FootballLeague.Data.DatabaseSeeder;
using FootballLeague.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Data.Context
{
    public class FootballLeagueContext : IdentityDbContext<IdentityUser>
    {
        public FootballLeagueContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TeamMatches> TeamMatches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMatchesConfiguration());

            modelBuilder.UpdateMatches();
            modelBuilder.UpdateTeamMatches();
            modelBuilder.UpdateTeams();

            base.OnModelCreating(modelBuilder);
        }
    }
}
