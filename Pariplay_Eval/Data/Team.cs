namespace Pariplay_Eval.Data
{
    public class Team
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Match>? Matches { get; set; }
        public ICollection<Standing> Standings { get; set; }
    }
}
