using System.Text.Json.Serialization;

namespace Pariplay_Eval.Data
{
    public class Team
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public ICollection<Match>? Matches { get; set; }
    }
}
