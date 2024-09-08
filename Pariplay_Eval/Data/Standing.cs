namespace Pariplay_Eval.Data
{
    public class Standing
    {
        public int Points { get; set; }
        public int PlayedGames { get; set; }
        public int Victories { get; set; }
        public int Draws { get; set; }
        public int Defeats { get; set; }
        public int GoalDifference { get; set; }
        public Team Team { get; set; }
        public Guid TeamId { get; set; }
        public string LeagueName { get; set; }
    }
}
