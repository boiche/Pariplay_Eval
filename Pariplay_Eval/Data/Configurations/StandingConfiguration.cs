using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pariplay_Eval.Data.Configurations
{
    public class StandingConfiguration : IEntityTypeConfiguration<Standing>
    {
        public void Configure(EntityTypeBuilder<Standing> builder)
        {
            builder.HasKey(x => new { x.TeamId, x.LeagueName });
            builder.HasOne(x => x.Team)
                .WithMany(x => x.Standings)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
