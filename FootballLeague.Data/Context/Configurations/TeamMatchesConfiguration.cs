using FootballLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Data.Context.Configurations
{
    public class TeamMatchesConfiguration : IEntityTypeConfiguration<TeamMatches>
    {
        public void Configure(EntityTypeBuilder<TeamMatches> builder)
        {
            builder.HasKey(tm => new { tm.TeamId, tm.MatchId });

            builder.HasOne(t => t.Team)
                .WithMany(tm => tm.TeamMatches)
                .HasForeignKey(t => t.TeamId);

            builder.HasOne(m => m.Match)
                .WithMany(tm => tm.TeamMatches)
                .HasForeignKey(m => m.MatchId);
        }
    }
}
