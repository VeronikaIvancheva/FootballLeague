using FootballLeague.Data.Context.Configurations;
using FootballLeague.Data.DatabaseSeeder;
using FootballLeague.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Data.Context
{
    public class FootballLeagueContext : IdentityDbContext<User>
    {
        public FootballLeagueContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
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
            modelBuilder.UpdateUsers();

            base.OnModelCreating(modelBuilder);
        }
    }
}
