using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pariplay_Eval.Data
{
    public class Match
    {
        public Guid? Id { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Guid? HomeTeamId { get; set; }
        [NotMapped]
        public Team? HomeTeam { get; set; }
        public Guid? AwayTeamId { get; set; }
        [NotMapped]
        public Team? AwayTeam { get; set; }
        public Guid? LeagueId { get; set; }
        [NotMapped]
        public League? League { get; set; }
    }
}
