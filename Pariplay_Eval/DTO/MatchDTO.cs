namespace Pariplay_Eval.DTO
{
    public class MatchDTO
    {
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Guid? HomeTeamId { get; set; }        
        public Guid? AwayTeamId { get; set; }
        public string LeagueName { get; set; }
    }
}
