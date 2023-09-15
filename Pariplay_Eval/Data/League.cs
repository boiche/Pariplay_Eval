namespace Pariplay_Eval.Data
{
    public class League
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public ICollection<Match>? Matches { get; set; }
    }
}
