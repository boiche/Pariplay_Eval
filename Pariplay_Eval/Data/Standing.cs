using System.ComponentModel.DataAnnotations.Schema;

namespace Pariplay_Eval.Data
{
    public class Standing
    {
        public string TeamName { get; set; }
        public int Points { get; set; }
        public int PlayedGames { get; set; }
        public int Victories { get; set; }
        public int Draws { get; set; }
        public int Defeats { get; set; }
        public int GoalDifference { get; set; }
    }
}
