using Pariplay_Eval.Data;

namespace Pariplay_Eval.Services.Interfaces
{
    public interface IMatchesService
    {
        void CreateMatch(Match match);
        void DeleteMatch(Guid id);
        Match? GetMatch(Guid id);
        IEnumerable<Match> GetMatches();
        void UpdateMatch(Guid id, Match match);
    }
}
