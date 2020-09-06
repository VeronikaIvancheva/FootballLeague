using FootballLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Data.Context.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(s => s.MatchId);

            builder.HasMany(tm => tm.TeamMatches)
                .WithOne(m => m.Match);
        }
    }
}
