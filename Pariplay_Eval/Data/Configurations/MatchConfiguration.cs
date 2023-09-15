using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pariplay_Eval.Data.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(x => x.Id);
            builder                                
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.Matches)                
                .HasConstraintName("FK_Match_HomeTeam")
                .HasForeignKey(x => x.HomeTeamId);
            builder
                .HasOne(x => x.League)
                .WithMany(x => x.Matches)
                .IsRequired(false)
                .HasForeignKey(x => x.LeagueId);
        }
    }
}
