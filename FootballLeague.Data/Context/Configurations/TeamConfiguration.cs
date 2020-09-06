using FootballLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Data.Context.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(s => s.TeamId);

            builder.HasMany(tm => tm.TeamMatches)
                .WithOne(t => t.Team);
        }
    }
}
